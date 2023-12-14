using Microsoft.Extensions.Logging;
using PraiseAPI.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Domain.DTOs.ResponseModels.Extensions
{
    public static class ApiResponseExtensions
    {
        public static BaseResponse LogResponse(this BaseResponse response, IApiLogService logService)
        {
            if(response.HasError())
                logService.Log(response.Error);

            return response;
        }
    }
}
