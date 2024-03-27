using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using PraiseAPI.Domain.Services;
using PraiseAPI.Infrastructure.Utilities.ResponseModels;
using System.Net;

namespace PraiseAPI.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IApiLogService _apiLog;
        protected readonly IHttpContextAccessor _contextAccessor;
        protected readonly string _clientId;
        public bool ShouldReturnDataOnly => _clientId == "praise-game";

        public BaseController(IApiLogService apiLog, IHttpContextAccessor contextAccessor) : base()
        {
            _apiLog = apiLog;
         
            _contextAccessor = contextAccessor;

            string clientId = _contextAccessor.HttpContext.Request.Headers["X-Client-Id"];

            _clientId = string.IsNullOrEmpty(clientId) ? "praise-api" : clientId;
        }

        protected IActionResult LogResponse(ApiError error)
        {
            error.Msg = $"ACTION RESULT :: API_ERROR :: {error.Msg}";

            _apiLog.Log(error);

            switch (error.ErrorCode)
            {
                case (-1):
                    return Ok(error);
                case (-2):
                    return StatusCode((int)HttpStatusCode.InternalServerError,error);
                case ((int)HttpStatusCode.InternalServerError):
                    return StatusCode((int)HttpStatusCode.InternalServerError, error);
                default:
                    return Ok(error);
            }
        }
    }
}
