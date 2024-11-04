using Microsoft.EntityFrameworkCore;
using UDV_Benefits.Domain.Errors;
using UDV_Benefits.Domain.Interfaces.BenefitRequestService;
using UDV_Benefits.Domain.Models;
using UDV_Benefits.Infrastructure.Data;
using UDV_Benefits.Domain.Enums;

namespace UDV_Benefits.Services.BenefitRequestService
{
    public class BenefitRequestService : IBenefitRequestService
    {
        private readonly AppDbContext _dbContext;

        public BenefitRequestService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result> AddBenefitRequestAsync(BenefitRequest benefitRequest)
        {
            var existingBenefitRequest = await _dbContext.BenefitRequests
                .FirstOrDefaultAsync(br =>
                br.Benefit == benefitRequest.Benefit 
                && br.Employee == benefitRequest.Employee
                && br.Status == benefitRequest.Status
                && br.Status == RequestStatus.PendingReview);
            //TODO: проверка на то, что у сотрудника эта льгота не активирована
            if (existingBenefitRequest != null) 
            {
                return BenefitRequestErrors.BenefitRequestExists;
            }
            await _dbContext.BenefitRequests.AddAsync(benefitRequest);
            await _dbContext.SaveChangesAsync();
            return Result.Success();
        }

        public async Task<List<BenefitRequest>> GetWorkerBenefitRequestsAsync(Guid userId)
        {
            var benefitRequests = await _dbContext.BenefitRequests
                .Include(br => br.Benefit)
                .Include(br => br.Employee)
                .ThenInclude(e => e.User)
                .Where(br => br.Employee.UserId == userId)
                .ToListAsync();
            return benefitRequests;
        }
    }
}
