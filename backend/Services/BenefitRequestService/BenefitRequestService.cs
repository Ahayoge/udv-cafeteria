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
                && br.Status == RequestStatus.PendingReview);
            if (existingBenefitRequest != null)
                return BenefitRequestErrors.BenefitRequestExists;

            var activatedEmployeeBenefit = await _dbContext.EmployeeBenefits
                .FirstOrDefaultAsync(eb => 
                eb.BenefitId == benefitRequest.Benefit.Id
                && eb.EmployeeId == benefitRequest.Employee.Id
                && eb.Status == EmployeeBenefitStatus.Active);
            if (activatedEmployeeBenefit != null)
                return EmployeeBenefitErrors.EmployeeBenefitIsActive;

            await _dbContext.BenefitRequests.AddAsync(benefitRequest);
            await _dbContext.SaveChangesAsync();
            return Result.Success();
        }

        public async Task<List<BenefitRequest>> GetBenefitRequestsByEmployeeIdAsync(Guid employeeId)
        {
            var benefitRequests = await _dbContext.BenefitRequests
                .Include(br => br.Benefit)
                .Where(br => br.EmployeeId == employeeId)
                .ToListAsync();
            return benefitRequests;
        }
    }
}
