using PraiseAPI.Domain.DTOs.RequestModels;
using PraiseAPI.Domain.DTOs.ResponseModels;
using PraiseAPI.Infrastructure.Utilities.ResponseModels;

namespace PraiseAPI.Domain.Services
{
    public interface IAuthService
    {
        SingleResponse<LoginResponse> Login(Login userLogin, string appId);
        BaseResponse Logout(string userEmail);
        string CreateAnonymousToken(string appId);
        string CreateUserToken(string userName, string email, DateTime expiration, string appId);
        string HashPass(string password);
        bool CheckPass(string password, string hashedPass);
        //string GetAnonymousToken()
        //HashPass(string userPass)
        //ValidatePass(string userPass)

    }
}
