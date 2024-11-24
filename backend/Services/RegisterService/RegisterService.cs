using UDV_Benefits.Domain.Errors;
using UDV_Benefits.Domain.Interfaces.AuthService;
using UDV_Benefits.Domain.Interfaces.RegisterService;
using UDV_Benefits.Domain.Interfaces.UserService;
using UDV_Benefits.Domain.Models;
using UDV_Benefits.Utilities;

namespace UDV_Benefits.Services.RegisterService
{
    public class RegisterService : IRegisterService
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public RegisterService(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        public async Task<ValueResult<string>> RegisterAsync(User user, string password)
        {
            user.PasswordHash = PasswordHasher.ComputeHash(password);
            var userResult = await _userService.AddUserAsync(user);
            if (userResult.IsFailure)
            {
                return userResult.Error;
            }
            var accessToken = await _authService.CreateAccessToken(user);
            return accessToken;
        }
    }
}
