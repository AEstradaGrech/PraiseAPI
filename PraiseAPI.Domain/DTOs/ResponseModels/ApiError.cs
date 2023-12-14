using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PraiseAPI.Infrastructure.Utilities.ResponseModels
{
    public class ApiError
    {
        public ApiError() { }

        public ApiError(int errorCode, string msg)
        {
            ErrorCode = errorCode;
            Msg = msg;
        }

        public string Msg { get; set; }
        public int ErrorCode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public LogLevel GetLogLevel()
            => ErrorCode switch {
                (-1) => LogLevel.Warning,
                (-2) => LogLevel.Error,
                ((int)HttpStatusCode.InternalServerError) => LogLevel.Critical,
                _ => LogLevel.Information
            };
    }
}
