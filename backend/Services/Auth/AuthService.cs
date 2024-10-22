using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UDV_Benefits.Domain.Interfaces;
using UDV_Benefits.Domain.Models;
using UDV_Benefits.Domain.Errors;
using UDV_Benefits.Utilities;
using UDV_Benefits.Infrastructure.Data;

namespace UDV_Benefits.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _dbContext;
        private readonly IUserService _userService;
        public readonly IWorkerService _workerService;

        public AuthService(IUserService userService, IWorkerService workerService, AppDbContext dbContext)
        {
            _userService = userService;
            _workerService = workerService;
            _dbContext = dbContext;
        }

        public async Task<ValueResult<string>> LoginAsync(string email, string password)
        {
            var userResult = await _userService.FindByEmailAsync(email);

            if (userResult.IsFailure
                || !_userService.CheckPassword(userResult.Value, password))
                return LoginErrors.WrongCredentials;

            var user = userResult.Value;
            var accessToken = await CreateAccessToken(user);
            return accessToken;
        }

        public async Task<ValueResult<string>> RegisterAsync(User user, string password)
        {
            user.PasswordHash = PasswordHasher.ComputeHash(password);
            var userResult = await _userService.AddUserAsync(user);
            if (userResult.IsFailure)
            {
                return userResult.Error;
            }

            var worker = user.Worker;
            var workerResult = await _workerService.AddWorkerAsync(worker);
            if (workerResult.IsFailure)
            {
                return workerResult.Error;
            }

            await _dbContext.SaveChangesAsync();
            var accessToken = await CreateAccessToken(user);
            return accessToken;
        }

        private async Task<String> CreateAccessToken(User user)
        {
            var userRoles = await _userService.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                new Claim("userId", user.Id.ToString())
            };
            foreach (var userRole in userRoles)
                claims.Add(new Claim(ClaimTypes.Role, userRole.ToString()));
            var accessToken = TokenGenerator.GenerateAccessToken(claims);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(accessToken);
            return tokenString;
        }
    }
}
