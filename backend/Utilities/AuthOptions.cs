using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace UDV_Benefits.Utilities
{
    public static class AuthOptions
    {
        public const string ISSUER = "UdvServer";
        public const string AUDIENCE = "UdvClient";
        public const int EXPIRES_MINUTES = 120;
        const string KEY = "mysupersecret_secretsecretsecretkey!123";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
