using Microsoft.EntityFrameworkCore;
using UDV_Benefits.Domain.Errors;
using UDV_Benefits.Domain.Interfaces.BenefitService;
using UDV_Benefits.Domain.Interfaces.CategoryService;
using UDV_Benefits.Domain.Models;
using UDV_Benefits.Domain.Enums;
using UDV_Benefits.Infrastructure.Data;
using UDV_Benefits.Domain.Interfaces.BenefitRequestService;
using UDV_Benefits.Domain.Interfaces.EmployeeBenefitService;

namespace UDV_Benefits.Services.BenefitService
{
    public class BenefitService : IBenefitService
    {
        private readonly AppDbContext _dbContext;
        private readonly IBenefitRequestService _benefitRequestService;
        private readonly IEmployeeBenefitService _employeeBenefitService;

        public BenefitService(AppDbContext dbContext, 
            IBenefitRequestService benefitRequestService, 
            IEmployeeBenefitService employeeBenefitService)
        {
            _dbContext = dbContext;
            _benefitRequestService = benefitRequestService;
            _employeeBenefitService = employeeBenefitService;
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

        public async Task<Result> ApplyForBenefitAsync(Employee employee, Benefit benefit)
        {
            if (benefit.ExperienceYearsRequired != null)
            {
                if (benefit.ExperienceYearsRequired >
                DateOnly.FromDateTime(DateTime.Today).Year - employee.StartedWorkWhen.Year)
                {
                    return BenefitRequestErrors.BenefitRequestNoAccessExperience;
                }
            }
            if (benefit.OnboardingRequired)
            {
                if (!employee.IsOnboarded)
                {
                    return BenefitRequestErrors.BenefitRequestNoAccessOnboarding;
                }
            }
            if (benefit.UcoinPrice != null)
            {
                if (employee.Ucoins < benefit.UcoinPrice)
                {
                    return BenefitRequestErrors.BenefitRequestNoAccessUcoins;
                }

                employee.Ucoins = benefit.UcoinPrice != null
                ? employee.Ucoins - (int)benefit.UcoinPrice
                : employee.Ucoins;
            }

            var benefitRequest = new BenefitRequest
            {
                AppliedWhen = DateOnly.FromDateTime(DateTime.Today),
                StatusChangedWhen = DateOnly.FromDateTime(DateTime.Today),
                Status = RequestStatus.Approved, //TODO: поменять на PendingReview
                Benefit = benefit,
                Employee = employee
            };

            var benefitRequestResult = await _benefitRequestService.AddBenefitRequestAsync(benefitRequest);
            if (benefitRequestResult.IsFailure)
                return benefitRequestResult.Error!;
            //TODO: можно было бы сделать транзакцию?
            if (benefitRequest.Status == RequestStatus.Approved)
            {
                var employeeBenefit = new EmployeeBenefit 
                {
                    Status = EmployeeBenefitStatus.Active,
                    ActivatedWhen = benefitRequest.AppliedWhen,
                    DeactivatedWhen = benefitRequest.AppliedWhen.AddDays(benefit.ValidityPeriodDays),
                    Employee = employee,
                    Benefit = benefit
                };
                var employeeBenefitResult = await _employeeBenefitService.AddEmployeeBenefitAsync(employeeBenefit);
                if (employeeBenefitResult.IsFailure)
                    return employeeBenefitResult.Error!;
            }
            
            return Result.Success();
        }

        public async Task<List<Benefit>> GetAllBenefitsAsync()
        {
            var benefits = await _dbContext.Benefits
                .ToListAsync();
            return benefits;
        }

        public async Task<ValueResult<Benefit>> GetBenefitByIdWorkerAsync(Guid id)
        {
            var benefitResult = await _dbContext.Benefits
                .FirstOrDefaultAsync(b => b.Id == id);
            if (benefitResult == null)
            {
                return BenefitErrors.BenefitNotFoundById;
            }
            return benefitResult;
        }
    }
}
