using UDV_Benefits.Domain.Enums;
using UDV_Benefits.Domain.Models;
using UDV_Benefits.Domain.Errors;

namespace UDV_Benefits.Domain.Interfaces
{
    public interface IUserService
    {
        public Task<ValueResult<User>> FindByEmailAsync(string email);
        public bool CheckPassword(User user, string password);
        public Task<List<Role>> GetRolesAsync(User user);
        public Task<Result> AddUserAsync(User user);
    }
}
