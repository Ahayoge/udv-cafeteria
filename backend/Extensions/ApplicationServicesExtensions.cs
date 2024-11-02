using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using UDV_Benefits.Domain.Enums;
using UDV_Benefits.Utilities;

namespace UDV_Benefits.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static void ConfigureAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidAudience = AuthOptions.AUDIENCE,
                    ValidIssuer = AuthOptions.ISSUER,
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey()
                };
            });
        }

        public static void ConfigureAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policy.Worker, new AuthorizationPolicyBuilder()
                    .RequireRole(nameof(Role.Worker))
                    .RequireAuthenticatedUser()
                    .Build());
                options.AddPolicy(Policy.Admin, new AuthorizationPolicyBuilder()
                    .RequireRole(nameof(Role.Admin))
                    .RequireAuthenticatedUser()
                    .Build());
                options.AddPolicy(Policy.Authenticated, new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build());
            });
        }
    }
}
