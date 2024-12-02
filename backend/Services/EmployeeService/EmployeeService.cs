using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UDV_Benefits.Domain.Enums;
using UDV_Benefits.Domain.Errors;
using UDV_Benefits.Domain.Interfaces.EmployeeService;
using UDV_Benefits.Domain.Models;
using UDV_Benefits.Infrastructure.Data;

namespace UDV_Benefits.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _dbContext;

        public EmployeeService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> EmployeeExistsAsync(Employee employee)
        {
            var existingEmployee = await _dbContext.Employees
                .FirstOrDefaultAsync(e
                    => e.FirstName == employee.FirstName
                       && e.Patronymic == employee.Patronymic
                       && e.LastName == employee.LastName
                       && e.BirthDate == employee.BirthDate);
            return existingEmployee != null;
        }

        public async Task<ValueResult<Employee>> GetEmployeeById(Guid employeeId)
        {
            var employee = await _dbContext.Employees.FindAsync(employeeId);
            if (employee == null)
                return EmployeeErrors.EmployeeNotFoundById;
            return employee;
        }

        public Task<List<Employee>> GetEmployeesWithActiveBenefitId(Guid benefitId)
        {
            var employees = _dbContext.Employees
                .Where(e => e.EmployeeBenefits.Any(eb =>
                eb.BenefitId == benefitId &&
                eb.Status == EmployeeBenefitStatus.Active))
                .ToListAsync();
            return employees;
        }
    }
}
