using Microsoft.EntityFrameworkCore;
using UDV_Benefits.Domain.Errors;
using UDV_Benefits.Domain.Interfaces.BenefitService;
using UDV_Benefits.Domain.Interfaces.CategoryService;
using UDV_Benefits.Domain.Models;
using UDV_Benefits.Infrastructure.Data;

namespace UDV_Benefits.Services.BenefitService
{
    public class BenefitService : IBenefitService
    {
        private readonly AppDbContext _dbContext;

        public BenefitService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ValueResult<Benefit>> AddBenefitAsync(Benefit benefit)
        {
            var existingBenefit = await _dbContext.Benefits
                .FirstOrDefaultAsync(b => b.Name == benefit.Name);
            if (existingBenefit != null)
            {
                return BenefitErrors.BenefitExists;
            }
            await _dbContext.AddAsync(benefit);
            await _dbContext.SaveChangesAsync();
            return benefit;
        }

        public async Task<List<Benefit>> GetAllBenefitsAsync()
        {
            var benefits = await _dbContext.Benefits
                .ToListAsync();
            return benefits;
        }
    }
}
