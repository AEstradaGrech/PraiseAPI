
namespace PraiseAPI.Infrastructure.Configs
{
    public sealed class AuthConfig
    {
        public string JwtKey { get; set; }
        public string JwtIssuer { get; set; }
        public int JwtExpirationMins { get; set; }
        public int PassHashSalt { get; set; }
        public int PassKeySize { get; set; }
        public int PassHashIterations { get; set; }
    }
}
