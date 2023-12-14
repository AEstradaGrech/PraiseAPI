using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PraiseAPI.Domain.DTOs.RequestModels;
using PraiseAPI.Domain.DTOs.ResponseModels;
using PraiseAPI.Domain.DTOs.ResponseModels.Extensions;
using PraiseAPI.Domain.Entities;
using PraiseAPI.Domain.Repositories;
using PraiseAPI.Domain.Services;
using PraiseAPI.Infrastructure.Configs;
using PraiseAPI.Infrastructure.Utilities.ResponseModels;
using PraiseAPI.Resources;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PraiseAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly AuthConfig _authConfig;

        private readonly IRolesMgmtService _rolesMgmtService;
        private readonly IUsersRepository _usersRepository;
        private readonly IPasswordHasher _passHasher;
        private readonly IApiLogService _logService;
        private readonly IStringLocalizer _errorLoc;

        public AuthService(IOptions<AuthConfig> authConfig, IRolesMgmtService rolesMgmtService, IUsersRepository usersRepo,
            IPasswordHasher passHasher, IApiLogService apiLog, IStringLocalizer<ErrorMsg> errorLoc)
        {
            _authConfig = authConfig.Value;
            _rolesMgmtService = rolesMgmtService;
            _usersRepository = usersRepo;
            _passHasher = passHasher;
            _logService = apiLog;
            _errorLoc = errorLoc;
        }

        public SingleResponse<LoginResponse> Login(Login userLogin, string appId)
        {
            if (string.IsNullOrEmpty(userLogin.UserName) && string.IsNullOrEmpty(userLogin.UserEmail))
                return new SingleResponse<LoginResponse>(-1, "Es necesario un nombre de usuario o un email para logearse")
                    .LogResponse(_logService) as SingleResponse<LoginResponse>;
            //get user
            PraiseUser user = string.IsNullOrEmpty(userLogin.UserName) ?
                _usersRepository.GetByEmail(userLogin.UserEmail) :
                _usersRepository.GetByNickname(userLogin.UserName);

            if (user == null)
                return new SingleResponse<LoginResponse>(-1, $"{nameof(AuthService)}-{nameof(Login)} - " + _errorLoc["DbError-GET"])
                    .LogResponse(_logService) as SingleResponse<LoginResponse>;

            //TODO: check Hash
            if(!CheckPass(userLogin.Password, user.Password))
                return new SingleResponse<LoginResponse>(-1, $"{nameof(AuthService)}-{nameof(Login)} - " + _errorLoc["AuthError-PASS_MATCH"])
                    .LogResponse(_logService) as SingleResponse<LoginResponse>;

            DateTime tokenExpiration = DateTime.Now.AddMinutes(_authConfig.JwtExpirationMins);

            var token = CreateUserToken(user.NickName, user.Email, tokenExpiration, appId);

            return !string.IsNullOrEmpty(token) ? new SingleResponse<LoginResponse>(new LoginResponse(user.NickName, user.Email, token, tokenExpiration)) :
                new SingleResponse<LoginResponse>(-1, $"{nameof(AuthService)}-{nameof(Login)} - " + "Se ha producido un fallo al generar el token de acceso")
                     .LogResponse(_logService) as SingleResponse<LoginResponse>; 
        }

        public string CreateUserToken(string userName, string email, DateTime expiration, string appId)
        {
            var userRoles = _rolesMgmtService.GetUserRoles(userName);

            if(userRoles.HasError())
            {
                // LOG
                return "";
            }

            var key = Encoding.UTF8.GetBytes(_authConfig.JwtKey);

            var tokenDesc = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("SessionId", Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, userName),
                    new Claim(JwtRegisteredClaimNames.Email, email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = expiration,
                Issuer = _authConfig.JwtIssuer,
                Audience = appId,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            for(int i = 0; i < userRoles.Data.Count; i++)
                tokenDesc.Subject.AddClaim(new Claim($"prs_rol_{i}", userRoles.Data[i].Name));

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDesc);
            return tokenHandler.WriteToken(token);
        }

        public string HashPass(string password)
            => _passHasher.HashPass(password, _authConfig.PassHashSalt, _authConfig.PassKeySize, _authConfig.PassHashIterations);

        public bool CheckPass(string password, string hashedPass)
            => _passHasher.CheckPass(password, hashedPass, _authConfig.PassKeySize);

        public string CreateAnonymousToken(string appId)
        {
            var anonRole = _rolesMgmtService.GetRole("anon");

            if (anonRole.HasError())
            {
                // LOG
                return "";
            }

            var key = Encoding.UTF8.GetBytes(_authConfig.JwtKey);

            var tokenDesc = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("SessionId", Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, "praise-app"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.Now.AddDays(1),
                Issuer = _authConfig.JwtIssuer,
                Audience = appId,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            tokenDesc.Subject.AddClaim(new Claim($"prs_rol_0", anonRole.Data.Name));

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDesc);

            return tokenHandler.WriteToken(token);
        }

        public BaseResponse Logout(string userEmail)
        {
            var user = _usersRepository.GetByEmail(userEmail);

            if (user == null)
                return new BaseResponse(-1, $"{nameof(AuthService)}-{nameof(Logout)} - " + _errorLoc["DbError-GET"]);

            user.IsLogged = false;
            //user.LastLogout = DateTime.Now;
            //user.CurrentToken = "";

            return _usersRepository.Update(user) != null ? new BaseResponse() :
               new BaseResponse(-1, $"{nameof(AuthService)}-{nameof(Logout)} - " + _errorLoc["DbError-UPDATE"]);
        }
    }
}
