using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UDV_Benefits.Domain.Errors;
using UDV_Benefits.Domain.Interfaces.AuthService;
using UDV_Benefits.Domain.Interfaces.EmployeeService;
using UDV_Benefits.Domain.Interfaces.UserService;
using UDV_Benefits.Domain.Models;
using UDV_Benefits.Utilities;

namespace UDV_Benefits.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        public readonly IEmployeeService _employeeService;

        public AuthService(IUserService userService, IEmployeeService employeeService)
        {
            _userService = userService;
            _employeeService = employeeService;
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

        public async Task<string> CreateAccessToken(User user)
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
