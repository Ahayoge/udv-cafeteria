using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace UDV_Benefits.Utilities
{
    public static class TokenGenerator
    {
        public static JwtSecurityToken GenerateAccessToken(List<Claim> claims)
        {
            var authSigningKey = AuthOptions.GetSymmetricSecurityKey();

            var token = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
                expires: DateTime.Now.AddMinutes(AuthOptions.EXPIRES_MINUTES),
                claims: claims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }
    }
}
