using Newtonsoft.Json.Converters;
using PraiseAPI.Domain.Services;
using System.Security.Cryptography;

namespace PraiseAPI.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPass(string password, int saltSize, int keySize, int iterations)
        {
            var saltByte = RandomNumberGenerator.GetBytes(saltSize);

            var passSalt = Convert.ToBase64String(saltByte);

            var hash = Rfc2898DeriveBytes.Pbkdf2(password, saltByte, iterations, HashAlgorithmName.SHA512, keySize);

            return $"{Convert.ToBase64String(hash)}.{Convert.ToBase64String(BitConverter.GetBytes(iterations))}.{passSalt}";
        }

        public bool CheckPass(string password, string hashedPass, int keySize)
        {
            var hashParts = hashedPass.Split('.');

            if (hashParts.Length != 3) return false;

            var iters = BitConverter.ToInt32(Convert.FromBase64String(hashParts[1]));

            var saltByte = Convert.FromBase64String(hashParts[2]);

            var hash = Rfc2898DeriveBytes.Pbkdf2(password, saltByte, iters, HashAlgorithmName.SHA512, keySize);

            return CryptographicOperations.FixedTimeEquals(hash, Convert.FromBase64String(hashParts[0]));
        }

    }
}
