using UDV_Benefits.Domain.Models;

namespace UDV_Benefits.Domain.Interfaces.EmployeeService
{
    public interface IEmployeeService
    {
        public Task<bool> EmployeeExistsAsync(Employee employee);
    }
}
