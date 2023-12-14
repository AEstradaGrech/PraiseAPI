using PraiseAPI.Domain.Services;
using PraiseAPI.Infrastructure.Utilities.ResponseModels;

namespace PraiseAPI.Services
{
    public class ApiLogService : IApiLogService
    {
        private readonly ILogger<ApiLogService> _appLog;
        private readonly IMongoLogService _mongoLog;
        public ApiLogService(ILogger<ApiLogService> appLog, IMongoLogService mongoLog) 
        {
            _appLog = appLog;
            _mongoLog = mongoLog;
        }

        public void Log(ApiError error, bool logToFile = true)
        {
            Task.Factory.StartNew(() => {
                if (!_mongoLog.Log(error))
                {
                    _appLog.Log(LogLevel.Critical, $"{nameof(ApiLogService)}-{nameof(MongoLogService)} :: Fallo al insertar log a mongo DB...");

                    logToFile = true;
                }

                if (logToFile)
                    _appLog.Log(error.GetLogLevel(), error.Msg);
            }); 
        }

        public void Log(LogLevel logLevel, string msg, bool logToFile = true)
        {
            Task.Factory.StartNew(() => {
                if (!_mongoLog.Log(logLevel, msg))
                {
                    _appLog.Log(LogLevel.Critical, $"{nameof(ApiLogService)}-{nameof(MongoLogService)} :: Fallo al insertar log en mongo DB...");

                    logToFile = true;
                }

                if (logToFile)
                    _appLog.Log(logLevel, msg);
            });
        }

        public void LogToFile(LogLevel logLevel, string logMsg)
        {
            _appLog.Log(logLevel, logMsg);
        }
    }
}
