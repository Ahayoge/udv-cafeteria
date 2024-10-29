using UDV_Benefits.Domain.Errors;
using UDV_Benefits.Domain.Models;

namespace UDV_Benefits.Domain.Interfaces.AuthService
{
    public interface IAuthService
    {
        public Task<ValueResult<string>> LoginAsync(string email, string password);
        public Task<string> CreateAccessToken(User user);
    }
}
