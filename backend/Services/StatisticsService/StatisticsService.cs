using UDV_Benefits.Domain.Enums;
using UDV_Benefits.Domain.Interfaces.EmployeeBenefitService;
using UDV_Benefits.Domain.Interfaces.EmployeeService;
using UDV_Benefits.Domain.Interfaces.StatisticsService;
using UDV_Benefits.Domain.Models;

namespace UDV_Benefits.Services.StatisticsService
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IEmployeeBenefitService _employeeBenefitService;
        private readonly IEmployeeService _employeeService;

        public StatisticsService(IEmployeeBenefitService employeeBenefitService, IEmployeeService employeeService)
        {
            _employeeBenefitService = employeeBenefitService;
            _employeeService = employeeService;
        }

        public async Task<StatisticsResult> GetStatisticsAsync(Guid benefitId, StatisticsPeriod period, int periodNumber, int year)
        {
            var count = await _employeeBenefitService
                .GetCountOfEmployeeBenefitByBenefitIdAsync(benefitId, period, periodNumber, year);
            var employees = await _employeeService.GetEmployeesWithActiveBenefitId(benefitId);
            var statisticsResult = new StatisticsResult
            { 
                EmployeeBenefitCountPerBenefit = count,
                EmployeesWithActiveBenefit = employees
            };
            return statisticsResult;
        }
    }
}
