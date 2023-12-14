using PraiseAPI.Infrastructure.Utilities.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Domain.DTOs.ResponseModels
{
    public class BaseResponse
    {
        public BaseResponse() { Error = null; }

        public BaseResponse(int errorCode, string msg)
        {
            Error = new ApiError(errorCode, msg);
        }

        public ApiError? Error { get; set; }

        public bool HasError() => Error != null;
    }
}
