
using CryptoHelper;

namespace HomeworkApp.Cryptography
{
    public class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
        }
    }
}
