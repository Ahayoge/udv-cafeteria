using UDV_Benefits.Domain.DTO.Auth;
using UDV_Benefits.Domain.Enums;
using UDV_Benefits.Domain.Models;

namespace UDV_Benefits.Domain.Mapper
{
    public static class AuthMapper
    {
        public static User FromDto(this RegisterRequest registerRequest)
        {
            var user = new User
            {
                Email = registerRequest.Email
            };
            foreach (var role in registerRequest.Roles)
            {
                var userRole = new UserRole
                {
                    Role = (Role)Enum.Parse(typeof(Role), role, true)
                };
                user.UsersRoles.Add(userRole);
            }

            //TODO: словарь с соответствием русских названий английским
            var employee = new Employee
            {
                FirstName = registerRequest.FirstName,
                Patronymic = registerRequest.Patronymic,
                LastName = registerRequest.LastName,
                Phone = registerRequest.Phone,
                BirthDate = DateOnly.ParseExact(registerRequest.BirthDate, "dd.MM.yyyy"),
                Company = (Company)Enum.Parse(typeof(Company), registerRequest.Company, true),
                Department = (Department)Enum.Parse(typeof(Department), registerRequest.Department, true),
                Position = (Position)Enum.Parse(typeof(Position), registerRequest.Position, true),
                IsOnboarded = true, //HACK: заглушка, в будущем убрать
                Ucoins = 1000, //HACK: заглушка, в будущем убрать
                StartedWorkWhen = DateOnly.FromDateTime(DateTime.Today)
            };
            user.Employee = employee;

            return user;
        }
    }
}
