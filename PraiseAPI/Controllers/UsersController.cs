using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PraiseAPI.Domain.DTOs.RequestModels;
using PraiseAPI.Domain.DTOs.User;
using PraiseAPI.Domain.Services;
using System.Net;

namespace PraiseAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : PraiseApiControllerBase
    {
        //User
        //  BattlePass <- consumir como los cupones de BP. DAO + SP
        //  UserChars[]
        private readonly IUsersMgmtService _usersMgmtService;

        public UsersController(IUsersMgmtService usersMgmtService, IApiLogService apiLog, IHttpContextAccessor ctx) : base(apiLog, ctx)
        {
            _usersMgmtService = usersMgmtService; 
        }

        [HttpGet("id/{id}")]
        [Authorize("DefaultUser")]
        public async Task<IActionResult> Get(int id)
        {
            var response = _usersMgmtService.GetById(id);

            if (response != null)
                return response.HasError() ? LogResponse(response.Error) : Ok(response);

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpGet("{nickname}")]
        public async Task<IActionResult> Get(string nickname)
        {
            var response = _usersMgmtService.GetByNickName(nickname);

            if (response != null)
                return response.HasError() ? LogResponse(response.Error) : Ok(response);

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpGet("full-user/{userEmail}")]
        public async Task<IActionResult> GetFullUser(string userEmail)
        {
            var response = _usersMgmtService.GetFullUser(userEmail);

            if (response != null)
                return response.HasError() ? LogResponse(response.Error) : Ok(response);

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpGet("praise-game/{nickname}")]
        [Authorize("PraiseGame")]
        public async Task<IActionResult> GetGameUser(string nickname)
        {
            var response = _usersMgmtService.GetGameUser(nickname);

            if (response != null)
                return response.HasError() ? LogResponse(response.Error) : Ok(response.Data);

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] UserSignUpDto user)
        {
            var response = _usersMgmtService.Post(user);

            if (response != null)
                return response.HasError() ? LogResponse(response.Error) : Ok(response);

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UserDto user)
        {
            var response = _usersMgmtService.Update(user);

            if (response != null)
                return response.HasError() ? LogResponse(response.Error) : Ok(response);

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpDelete("delete/{userEmail}")]
        [Authorize("Admin")]
        public async Task<IActionResult> Delete(string userEmail)
        {
            var response = _usersMgmtService.Delete(userEmail);

            if (response != null)
                return response.HasError() ? LogResponse(response.Error) : Ok(response);

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpDelete("discharge/{userEmail}")]
        public async Task<IActionResult> Discharge(string userEmail)
        {
            var response = _usersMgmtService.Discharge(userEmail);

            if (response != null)
                return response.HasError() ? LogResponse(response.Error) : Ok(response);

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpPost("game/signup")]
        public async Task<IActionResult> GameSignUp([FromBody] GameSignUpRequest userSignUp)
        {
            var response = _usersMgmtService.GameSignUp(userSignUp);

            if (response != null)
                return response.HasError() ? LogResponse(response.Error) : Ok(response);

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
}
