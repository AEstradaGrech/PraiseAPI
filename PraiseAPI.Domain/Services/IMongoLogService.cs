using Microsoft.Extensions.Logging;
using PraiseAPI.Infrastructure.Utilities.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Domain.Services
{
    public interface IMongoLogService
    {
        bool Log(ApiError error);
        bool Log(LogLevel logLevel, string msg);
        Task<bool> LogAsync(ApiError error);
        Task<bool> DeleteAsync(ApiError error);
    }
}
