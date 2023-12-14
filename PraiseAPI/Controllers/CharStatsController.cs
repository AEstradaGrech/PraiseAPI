using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PraiseAPI.Domain.Services;

namespace PraiseAPI.Controllers
{
    [Route("api/char-stats")]
    [ApiController]
    public class CharStatsController : ControllerBase
    {
        private readonly ICharStatsMgmtService _statsMgmtService;

        public CharStatsController(ICharStatsMgmtService statsMgmtService)
        {
            _statsMgmtService = statsMgmtService;
        }
    }
}
