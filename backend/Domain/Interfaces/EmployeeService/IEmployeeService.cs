using UDV_Benefits.Domain.Enums;
using UDV_Benefits.Domain.Errors;
using UDV_Benefits.Domain.Models;

namespace UDV_Benefits.Domain.Interfaces.EmployeeService
{
    public interface IEmployeeService
    {
        public Task<ValueResult<Employee>> GetEmployeeById(Guid employeeId);
        public Task<bool> EmployeeExistsAsync(Employee employee);
        public Task<List<Employee>> GetEmployeesWithActiveBenefitId(Guid benefitId);
    }
}
