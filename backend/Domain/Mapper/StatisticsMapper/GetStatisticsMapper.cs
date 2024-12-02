using UDV_Benefits.Domain.DTO.Statistics;
using UDV_Benefits.Domain.Models;

namespace UDV_Benefits.Domain.Mapper.StatisticsMapper
{
    public static class GetStatisticsMapper
    {
        public static GetStatisticsResponse ToDto(this StatisticsResult statisticsResult)
        {
            var employees = statisticsResult.EmployeesWithActiveBenefit
                    .Select(e => new GetStatisticsResponse.EmployeeDto
                    {
                        FirstName = e.FirstName,
                        Patronymic = e.Patronymic,
                        LastName = e.LastName,
                        Department = e.Department.ToString()
                    })
                    .ToList();
            return new GetStatisticsResponse
            {
                EmployeeBenefitCountPerBenefit = statisticsResult.EmployeeBenefitCountPerBenefit,
                EmployeesWithActiveBenefit = employees,
                EmployeesCount = employees.Count
            };
        }
    }
}
