using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PraiseAPI.Domain.DTOs.RequestModels;
using PraiseAPI.Domain.Services;
using PraiseAPI.Infrastructure.Utilities.ResponseModels;
using System.Net;

namespace PraiseAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : PraiseApiControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUsersMgmtService _usersMgmtService;

        public AuthController(IAuthService authService, IUsersMgmtService usersMgmtService, IApiLogService apiLog, IHttpContextAccessor ctx) : base(apiLog, ctx)
        {
            _authService = authService;
            _usersMgmtService = usersMgmtService;
        }

        [HttpGet("anonymous")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAnonymousToken()
        {
            var token = _authService.CreateAnonymousToken(_clientId);

            return string.IsNullOrEmpty(token) ? LogResponse(new ApiError(-1, "Ha ocurrido un error al generar el token de aplicacion ")) : Ok(token);
        }

        [HttpPost("login")]
        [Authorize("Anonymous")]
        public async Task<IActionResult> Login([FromBody]Login userLogin)
        {
            var response = _authService.Login(userLogin, _clientId);

            if (response != null)
            {
                if (!response.HasError())
                {
                    _usersMgmtService.UpdateUserLoginStatus(response.Data.UserName, true);

                    return Ok(ShouldReturnDataOnly ? response.Data : response);
                }
                
                else return LogResponse(response.Error);
            }
               

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpPost("logout")]
        [Authorize("User")]
        public async Task<IActionResult> Logout(string email)
        {
            var response = _authService.Logout(email);

            if (response != null)
                return response.HasError() ? LogResponse(response.Error) : Ok();

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
}
