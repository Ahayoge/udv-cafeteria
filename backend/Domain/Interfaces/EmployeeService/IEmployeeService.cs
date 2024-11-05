using UDV_Benefits.Domain.Errors;
using UDV_Benefits.Domain.Models;

namespace UDV_Benefits.Domain.Interfaces.EmployeeService
{
    public interface IEmployeeService
    {
        public Task<bool> EmployeeExistsAsync(Employee employee);
        public Task<ValueResult<Employee>> GetProfileByUserIdAsync(Guid userId);
    }
}
