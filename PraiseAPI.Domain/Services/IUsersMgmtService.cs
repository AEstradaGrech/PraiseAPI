using PraiseAPI.Domain.DTOs.RequestModels;
using PraiseAPI.Domain.DTOs.RequestModels.Filters;
using PraiseAPI.Domain.DTOs.ResponseModels;
using PraiseAPI.Domain.DTOs.User;
using PraiseAPI.Infrastructure.Utilities.ResponseModels;

namespace PraiseAPI.Domain.Services
{
    public interface IUsersMgmtService
    {
        SingleResponse<UserDto> GetById(int id);
        SingleResponse<UserDto> GetByNickName(string nickName);
        SingleResponse<FullUserDto> GetFullUser(string userEmail);
        SingleResponse<GameUserDto> GetGameUser(string nickName);
        SingleResponse<UserDto> Delete(int id);
        SingleResponse<UserDto> Delete(string userEmail);
        SingleResponse<UserDto> Discharge(string userEmail);
        SingleResponse<UserDto> Post(UserSignUpDto userDto);
        SingleResponse<UserDto> Update(UserDto userDto);
        CollectionResponse<UserDto> GetAll();
        CollectionResponse<BasicUserDto> GetByFilter(UsersQueryFilter filter);
        SingleResponse<LoginResponse> GameSignUp(GameSignUpRequest req);
        BaseResponse UpdateUserLoginStatus(string userNickname, bool bStatus, string currentToken = "");
    }
}
