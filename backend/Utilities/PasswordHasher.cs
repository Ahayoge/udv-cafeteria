using System.Security.Cryptography;
using System.Text;

namespace UDV_Benefits.Utilities
{
    public static class PasswordHasher
    {
        public static string ComputeHash(string password)
        {
            var sha256 = SHA256.Create();
            var byteValue = Encoding.UTF8.GetBytes(password);
            var byteHash = sha256.ComputeHash(byteValue);
            return Convert.ToBase64String(byteHash);
        }
    }
}
