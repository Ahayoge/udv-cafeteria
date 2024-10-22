using Microsoft.EntityFrameworkCore;
using UDV_Benefits.Domain.Enums;
using UDV_Benefits.Domain.Errors;
using UDV_Benefits.Domain.Interfaces;
using UDV_Benefits.Domain.Models;
using UDV_Benefits.Infrastructure.Data;
using UDV_Benefits.Utilities;

namespace UDV_Benefits.Services.Auth
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;

        public UserService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result> AddUserAsync(User user)
        {
            var existingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (existingUser != null)
            {
                return UserErrors.UserExists;
            }

            await _dbContext.Users.AddAsync(user);
            return Result.Success();
        }

        public bool CheckPassword(User user, string password)
        {
            var hash = PasswordHasher.ComputeHash(password);
            var userHash = user.PasswordHash;
            return PasswordHasher.ComputeHash(password) == user.PasswordHash;
        }

        public async Task<ValueResult<User>> FindByEmailAsync(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return ValueResult<User>.Failure(UserErrors.UserNotFound);
            }
            return ValueResult<User>.Success(user);
        }

        public async Task<List<Role>> GetRolesAsync(User user)
        {
            var userWithRoles = await _dbContext.Users
                .Include(u => u.UsersRoles)
                .FirstAsync(u => u.Id == user.Id);
            var roles = userWithRoles.UsersRoles.
                Select(ur => ur.Role)
                .ToList();
            return roles;
        }
    }
}
