using Microsoft.EntityFrameworkCore;
using UDV_Benefits.Domain.Errors;
using UDV_Benefits.Domain.Interfaces.EmployeeBenefitService;
using UDV_Benefits.Domain.Models;
using UDV_Benefits.Domain.Enums;
using UDV_Benefits.Infrastructure.Data;
using System.Linq.Expressions;

namespace UDV_Benefits.Services.EmployeeBenefitService
{
    public class EmployeeBenefitService : IEmployeeBenefitService
    {
        private readonly AppDbContext _dbContext;

        public EmployeeBenefitService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> ActiveEmployeeBenefitExists(Employee employee, Benefit benefit)
        {
            var activatedEmployeeBenefit = await _dbContext.EmployeeBenefits
               .FirstOrDefaultAsync(eb =>
               eb.BenefitId == benefit.Id
               && eb.EmployeeId == employee.Id
               && eb.Status == EmployeeBenefitStatus.Active);
            return activatedEmployeeBenefit != null;
        }

        public async Task<Result> AddEmployeeBenefitAsync(EmployeeBenefit employeeBenefit)
        {
            await _dbContext.EmployeeBenefits.AddAsync(employeeBenefit);
            await _dbContext.SaveChangesAsync();
            return Result.Success();
        }

        public async Task<ValueResult<EmployeeBenefit>> GetActiveEmployeeBenefitById(Guid employeeBenefitId)
        {
            var result = await _dbContext.EmployeeBenefits
                .Include(eb => eb.Benefit)
                .ThenInclude(b => b.Category)
                .Where(eb => eb.Status == EmployeeBenefitStatus.Active)
                .FirstOrDefaultAsync(eb => eb.Id == employeeBenefitId);
            if (result == null)
                return EmployeeBenefitErrors.ActiveEmployeeBenefitNotFoundById;
            return result;
        }

        public async Task<List<EmployeeBenefit>> GetActiveEmployeeBenefitsByEmployeeIdAsync(Guid employeeId)
        {
            var result = await _dbContext.EmployeeBenefits
                .Include(eb => eb.Benefit)
                .ThenInclude(b => b.Category)
                .Where(eb => 
                eb.EmployeeId == employeeId
                && eb.Status == EmployeeBenefitStatus.Active)
                .ToListAsync();
            return result;
        }

        public async Task<int> GetCountOfEmployeeBenefitByBenefitIdAsync(Guid benefitId, StatisticsPeriod period, int periodNumber, int year)
        {
            Expression<Func<EmployeeBenefit, bool>> periodFilter;
            if (period == StatisticsPeriod.Month)
            {
                periodFilter = eb => eb.ActivatedWhen.Month == periodNumber && eb.ActivatedWhen.Year == year;
            }
            else if (period == StatisticsPeriod.Quarter)
            {
                periodFilter = eb => (eb.ActivatedWhen.Month - 1) / 3 + 1 == periodNumber 
                && eb.ActivatedWhen.Year == year;
            }
            else
            {
                periodFilter = eb => eb.ActivatedWhen.Year == year;
            }
            var employeeBenefitsCount = await _dbContext.EmployeeBenefits
                .Where(eb => eb.BenefitId == benefitId)
                .Where(periodFilter)
                .CountAsync();
            return employeeBenefitsCount;
        }
    }
}
