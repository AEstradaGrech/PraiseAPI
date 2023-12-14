using Microsoft.Extensions.Logging;
using PraiseAPI.Infrastructure.Utilities.ResponseModels;

namespace PraiseAPI.Domain.Services
{
    public interface IApiLogService
    {
        void Log(LogLevel logLevel, string msg, bool logToFile = true);
        void Log(ApiError error, bool logToFile = true);
        void LogToFile(LogLevel logLevel, string logMsg);
    }
}
