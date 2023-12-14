

namespace PraiseAPI.Domain.Services
{
    public interface IPasswordHasher
    {
        string HashPass(string password, int saltSize, int keySize, int iterations);
        bool CheckPass(string password, string hashedPass, int keySize);
    }
}
