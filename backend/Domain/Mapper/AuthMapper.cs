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
            user.UsersRoles.Add(new UserRole { Role = Role.Worker });
            if (registerRequest.IsAdmin)
                user.UsersRoles.Add(new UserRole { Role = Role.Admin });

            //TODO: словарь с соответствием русских названий английским
            var worker = new Worker
            {
                FirstName = registerRequest.FirstName,
                Patronymic = registerRequest.Patronymic,
                LastName = registerRequest.LastName,
                Phone = registerRequest.Phone,
                BirthDate = DateOnly.ParseExact(registerRequest.BirthDate, "dd.MM.yyyy"),
                Company = (Enums.Company)Enum.Parse(typeof(Enums.Company), registerRequest.Company, true),
                Department = (Enums.Department)Enum.Parse(typeof(Enums.Department), registerRequest.Department, true),
                Position = (Enums.Position)Enum.Parse(typeof(Enums.Position), registerRequest.Position, true),
                IsOnboarded = true,
                Ucoins = 1000,
                StartedWorkWhen = DateOnly.FromDateTime(DateTime.Today)
            };
            user.Worker = worker;

            return user;
        }
    }
}
