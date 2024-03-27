using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PraiseAPI.Domain.DTOs;
using PraiseAPI.Domain.DTOs.RequestModels.Filters;
using PraiseAPI.Domain.Services;
using System.Net;

namespace PraiseAPI.Controllers
{
    [Route("api/[controller]")]
    public class CharactersController : BaseController
    {

        //Character
        // CharName
        //  CreationDate
        //  CurrentGold
        //  CurrentLevel
        //  CurrentXP
        //  w/Stats (attributes

        private readonly ICharactersMgmtService _charactersMgmtService;

        public CharactersController(ICharactersMgmtService charactersMgmtService, IApiLogService apiLog, IHttpContextAccessor ctx) : base(apiLog, ctx)
        {
            _charactersMgmtService = charactersMgmtService;
        }

        [HttpPost("get-by-dao-filter")]
        public async Task<IActionResult> GetByFilter_DAO([FromBody] CharactersDaoFilter filter)
        {
            var response = _charactersMgmtService.GetByFilter_DAO(filter);

            if(response != null)
                return response.HasError() ? LogResponse(response.Error) : Ok(response);

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CharacterDto dto)
        {
            var response = _charactersMgmtService.Post(dto);

            if (response != null)
                return response.HasError() ? LogResponse(response.Error) : Ok(response);

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
}
