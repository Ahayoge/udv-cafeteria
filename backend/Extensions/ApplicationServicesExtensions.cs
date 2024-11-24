using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UDV_Benefits.Domain.Enums;
using UDV_Benefits.Domain.Models;
using UDV_Benefits.Infrastructure.Data;
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
                options.Events = new JwtBearerEvents()
                {
                    OnTokenValidated = async context =>
                    {
                        var userId = Guid.Parse(context.Principal.Claims.FirstOrDefault(c => c.Type == "userId")?.Value);
                        var dbcontext = context.HttpContext.RequestServices.GetRequiredService<AppDbContext>();
                        var user = await dbcontext.Users.FindAsync(userId);
                        if (user == null)
                        {
                            var failureMessage = "Пользователя с таким id не существует";
                            context.Fail(failureMessage);
                            Console.WriteLine(failureMessage);
                            return;
                        }
                    } //TODO: добавить установку сообщения об ошибке в WWW-Authenticate
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
