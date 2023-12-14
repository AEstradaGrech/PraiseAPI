using Microsoft.Extensions.Localization;
using PraiseAPI.Domain.Mappers;
using PraiseAPI.Domain.Services;
using PraiseAPI.Resources;

namespace PraiseAPI.Services
{
    public class CharStatsMgmtService : BaseMgmtService, ICharStatsMgmtService
    {
        private readonly ICharStatsMapperService _statsMapper;

        public CharStatsMgmtService(ICharStatsMapperService statsMapper, IApiLogService logService, IStringLocalizer<ErrorMsg> errorLoc) : base(logService, errorLoc) 
        {
            _statsMapper = statsMapper;
        }
    }
}
