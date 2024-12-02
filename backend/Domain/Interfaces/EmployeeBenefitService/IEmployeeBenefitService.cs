using UDV_Benefits.Domain.Enums;
using UDV_Benefits.Domain.Errors;
using UDV_Benefits.Domain.Models;

namespace UDV_Benefits.Domain.Interfaces.EmployeeBenefitService
{
    public interface IEmployeeBenefitService
    {
        public Task<Result> AddEmployeeBenefitAsync(EmployeeBenefit employeeBenefit);
        public Task<List<EmployeeBenefit>> GetActiveEmployeeBenefitsByEmployeeIdAsync(Guid employeeId);
        public Task<ValueResult<EmployeeBenefit>> GetActiveEmployeeBenefitById(Guid employeeBenefitId);
        public Task<bool> ActiveEmployeeBenefitExists(Employee employee, Benefit benefit);
        public Task<int> GetCountOfEmployeeBenefitByBenefitIdAsync(Guid benefitId, StatisticsPeriod period, int periodNumber, int year);
    }
}
