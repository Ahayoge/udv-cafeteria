using Microsoft.EntityFrameworkCore;
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
    }
}
