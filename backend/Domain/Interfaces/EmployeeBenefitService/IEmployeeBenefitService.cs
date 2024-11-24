using UDV_Benefits.Domain.Errors;
using UDV_Benefits.Domain.Models;

namespace UDV_Benefits.Domain.Interfaces.EmployeeBenefitService
{
    public interface IEmployeeBenefitService
    {
        public Task<Result> AddEmployeeBenefitAsync(EmployeeBenefit employeeBenefit);
        public Task<List<EmployeeBenefit>> GetActiveEmployeeBenefitsByEmployeeIdAsync(Guid employeeId);
    }
}
