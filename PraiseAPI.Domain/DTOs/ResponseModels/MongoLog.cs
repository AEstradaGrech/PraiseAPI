using Microsoft.Extensions.Logging;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Domain.DTOs.ResponseModels
{
    public class MongoLog
    {
        public MongoLog() { Id = setId(); }

        public MongoLog(string msg, LogLevel level) : this()
        {
            Msg = msg;
            Date = DateTime.Now;
            LogLevel = level.ToString();
        }

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string LogLevel { get; set; }
        public string Msg { get; set; }

        private string setId()
            => $"{DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year}-{Guid.NewGuid()}";

        public bool IsValid() 
            => !string.IsNullOrEmpty(Id) && !string.IsNullOrEmpty(Msg);
    }
}
