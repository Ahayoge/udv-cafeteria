using System.IdentityModel.Tokens.Jwt;
using UDV_Benefits.Domain.Errors;
using UDV_Benefits.Domain.Models;

namespace UDV_Benefits.Domain.Interfaces
{
    public interface IAuthService
    {
        public Task<ValueResult<string>> LoginAsync(string email, string password);
        public Task<ValueResult<string>> RegisterAsync(User user, string password);
    }
}
