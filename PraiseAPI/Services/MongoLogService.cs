using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PraiseAPI.Domain.DTOs.ResponseModels;
using PraiseAPI.Domain.Services;
using PraiseAPI.Infrastructure.Configs;
using PraiseAPI.Infrastructure.Utilities.ResponseModels;

namespace PraiseAPI.Services
{
    public class MongoLogService : IMongoLogService
    {
        private IMongoCollection<MongoLog> _logsCollection;

        public MongoLogService(IOptions<MongoDbConfig> mongoConfig) 
        {
            MongoClient mongoClient = new MongoClient(mongoConfig.Value.ConnectionURI);
            IMongoDatabase mongoDb = mongoClient.GetDatabase(mongoConfig.Value.DatabaseName);
            _logsCollection = mongoDb.GetCollection<MongoLog>(mongoConfig.Value.CollectionName);
        }

        public async Task<bool> DeleteAsync(ApiError error)
        {
            MongoLog log = new MongoLog(error.Msg, error.GetLogLevel());

            if (!log.IsValid()) return false;

            await _logsCollection.DeleteOneAsync(log.Id);

            return true;
        }

        public bool Log(ApiError error)
        {
            MongoLog log = new MongoLog(error.Msg, error.GetLogLevel());

            if (!log.IsValid()) return false;

            _logsCollection.InsertOne(log); 

            return true;
        }

        public bool Log(LogLevel logLevel, string msg)
        {
            MongoLog log = new MongoLog(msg, logLevel);

            if (!log.IsValid()) return false;

            _logsCollection.InsertOne(log);

            return true;
        }

        public async Task<bool> LogAsync(ApiError error)
        {
            MongoLog log = new MongoLog(error.Msg, error.GetLogLevel());

            if (!log.IsValid()) return false;

            _logsCollection.InsertOne(log);

            return true;
        }
    }
}
