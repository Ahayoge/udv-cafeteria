using Microsoft.EntityFrameworkCore;
using UDV_Benefits.Domain.Interfaces.BenefitService;
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

        public async Task<List<Benefit>> GetAllBenefitsAsync()
        {
            var benefits = await _dbContext.Benefits
                .ToListAsync();
            return benefits;
        }
    }
}
