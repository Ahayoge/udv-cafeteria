using UDV_Benefits.Domain.DTO.EmployeeBenefit.AllActive;
using UDV_Benefits.Domain.Models;

namespace UDV_Benefits.Domain.Mapper.EmployeeBenefitMapper
{
    public static class AllActiveMapper
    {
        public static IEnumerable<EmployeeBenefitDto> ToDto(this List<EmployeeBenefit> employeeBenefits)
        {
            return employeeBenefits.Select(eb => 
                new EmployeeBenefitDto
                {
                    Id = eb.Id,
                    Name = eb.Benefit.Name,
                    DeactivatedWhen = eb.DeactivatedWhen
                });
        }
    }
}
