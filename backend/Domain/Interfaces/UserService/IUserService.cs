using UDV_Benefits.Domain.Enums;
using UDV_Benefits.Domain.Errors;
using UDV_Benefits.Domain.Models;

namespace UDV_Benefits.Domain.Interfaces.UserService
{
    public interface IUserService
    {
        public Task<ValueResult<User>> FindByEmailAsync(string email);
        public bool CheckPassword(Models.User user, string password);
        public Task<List<Role>> GetRolesAsync(User user);
        public Task<Result> AddUserAsync(User user);
    }
}
