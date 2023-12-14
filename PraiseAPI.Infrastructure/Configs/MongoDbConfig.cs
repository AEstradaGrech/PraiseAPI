
namespace PraiseAPI.Infrastructure.Configs
{
    public sealed class MongoDbConfig
    {
        public string ConnectionURI { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }
}
