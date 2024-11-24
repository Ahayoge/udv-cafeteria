using Microsoft.EntityFrameworkCore;
using UDV_Benefits.Domain.Errors;
using UDV_Benefits.Domain.Interfaces.EmployeeBenefitService;
using UDV_Benefits.Domain.Models;
using UDV_Benefits.Domain.Enums;
using UDV_Benefits.Infrastructure.Data;

namespace UDV_Benefits.Services.EmployeeBenefitService
{
    public class EmployeeBenefitService : IEmployeeBenefitService
    {
        private readonly AppDbContext _dbContext;

        public EmployeeBenefitService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result> AddEmployeeBenefitAsync(EmployeeBenefit employeeBenefit)
        {
            await _dbContext.EmployeeBenefits.AddAsync(employeeBenefit);
            await _dbContext.SaveChangesAsync();
            return Result.Success();
        }

        public async Task<List<EmployeeBenefit>> GetActiveEmployeeBenefitsByEmployeeIdAsync(Guid employeeId)
        {
            var result = await _dbContext.EmployeeBenefits
                .Include(eb => eb.Benefit)
                .Where(eb => 
                eb.EmployeeId == employeeId
                && eb.Status == EmployeeBenefitStatus.Active)
                .ToListAsync();
            return result;
        }
    }
}
