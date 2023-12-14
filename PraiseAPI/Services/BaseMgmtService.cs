using Microsoft.Extensions.Localization;
using PraiseAPI.Domain.Services;
using PraiseAPI.Resources;

namespace PraiseAPI.Services
{
    public abstract class BaseMgmtService
    {
        protected readonly IApiLogService _logService;
        protected readonly IStringLocalizer<ErrorMsg> _errorLoc;

        public BaseMgmtService(IApiLogService logService, IStringLocalizer<ErrorMsg> errorLoc)
        {
            _logService = logService;
            _errorLoc = errorLoc;
        }
    }
}
