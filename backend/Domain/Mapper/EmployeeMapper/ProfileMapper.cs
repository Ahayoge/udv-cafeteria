using UDV_Benefits.Domain.DTO.Employee;
using UDV_Benefits.Domain.Models;

namespace UDV_Benefits.Domain.Mapper.EmployeeMapper
{
    public static class ProfileMapper
    {
        public static GetProfileResponse ToDto<T>(this Employee employee) where T : GetProfileResponse
        {
            return new GetProfileResponse
            {
                FirstName = employee.FirstName,
                Patronymic = employee.Patronymic,
                LastName = employee.LastName,
                Ucoins = employee.Ucoins,
                ExperienceYears = 
                    DateOnly.FromDateTime(DateTime.Today).Year 
                    - employee.StartedWorkWhen.Year
            };
        }
    }
}
