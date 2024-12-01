using Microsoft.EntityFrameworkCore;
using UDV_Benefits.Domain.Errors;
using UDV_Benefits.Domain.Interfaces.BenefitRequestService;
using UDV_Benefits.Domain.Models;
using UDV_Benefits.Infrastructure.Data;
using UDV_Benefits.Domain.Enums;
using UDV_Benefits.Domain.Interfaces.EmployeeBenefitService;

namespace UDV_Benefits.Services.BenefitRequestService
{
    public class BenefitRequestService : IBenefitRequestService
    {
        private readonly AppDbContext _dbContext;
        private readonly IEmployeeBenefitService _employeeBenefitService;

        public BenefitRequestService(AppDbContext dbContext, 
            IEmployeeBenefitService employeeBenefitService)
        {
            _dbContext = dbContext;
            _employeeBenefitService = employeeBenefitService;
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

        public async Task<Result> ApproveBenefitRequestByIdAsync(Guid benefitRequestId)
        {
            var benefitRequest = await _dbContext.BenefitRequests
                .Include(br => br.Benefit)
                .Include(br => br.Employee)
                .FirstOrDefaultAsync(br => br.Id == benefitRequestId);
            if (benefitRequest == null)
                return BenefitRequestErrors.BenefitRequestNotFoundById;
            benefitRequest.Status = RequestStatus.Approved;
            benefitRequest.StatusChangedWhen = DateOnly.FromDateTime(DateTime.Today);

            var benefit = benefitRequest.Benefit;
            var employeeBenefit = new EmployeeBenefit
            {
                Status = EmployeeBenefitStatus.Active,
                ActivatedWhen = DateOnly.FromDateTime(DateTime.Today),
                DeactivatedWhen = DateOnly.FromDateTime(DateTime.Today).AddDays(benefit.ValidityPeriodDays),
                DmsProgram = benefitRequest.DmsProgram,
                EmployeeId = benefitRequest.EmployeeId,
                BenefitId = benefitRequest.BenefitId
            };
            var employeeBenefitResult = await _employeeBenefitService.AddEmployeeBenefitAsync(employeeBenefit);
            if (employeeBenefitResult.IsFailure)
                return employeeBenefitResult.Error!;

            await _dbContext.SaveChangesAsync();
            return Result.Success();
        }

        public async Task<List<BenefitRequest>> GetBenefitRequestsByEmployeeIdAsync(Guid employeeId)
        {
            var benefitRequests = await _dbContext.BenefitRequests
                .Include(br => br.Benefit)
                .ThenInclude(b => b.Category)
                .Where(br => br.EmployeeId == employeeId)
                .ToListAsync();
            return benefitRequests;
        }

        public async Task<Result> RejectBenefitRequestByIdAsync(Guid benefitRequestId, string reason)
        {
            var benefitRequest = await _dbContext.BenefitRequests
                .FirstOrDefaultAsync(br => br.Id == benefitRequestId);
            if (benefitRequest == null)
                return BenefitRequestErrors.BenefitRequestNotFoundById;
            benefitRequest.Status = RequestStatus.Rejected;
            benefitRequest.StatusChangedWhen = DateOnly.FromDateTime(DateTime.Now);
            benefitRequest.RejectionReason = reason;
            await _dbContext.SaveChangesAsync();
            return Result.Success();
        }
    }
}
