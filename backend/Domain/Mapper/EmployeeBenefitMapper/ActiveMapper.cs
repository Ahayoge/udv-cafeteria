using UDV_Benefits.Domain.DTO.EmployeeBenefit.ActiveById;
using UDV_Benefits.Domain.Models;

namespace UDV_Benefits.Domain.Mapper.EmployeeBenefitMapper
{
    public static class ActiveMapper
    {
        public static GetActiveEmployeeBenefitResponse ToDto<T>(this EmployeeBenefit employeeBenefit)
            where T : GetActiveEmployeeBenefitResponse
        {
            var benefit = employeeBenefit.Benefit;
            return new GetActiveEmployeeBenefitResponse
            {
                Id = employeeBenefit.Id,
                Name = benefit.Name,
                Description = benefit.Description,
                DeactivatedWhen = employeeBenefit.DeactivatedWhen,
                AdditionalInfo = benefit.AdditionalInfo,
                Conditions = new GetActiveEmployeeBenefitResponse.ConditionsDto
                {
                    ExperienceYearsRequired = benefit.ExperienceYearsRequired,
                    UcoinPrice = benefit.UcoinPrice,
                    FormUrl = benefit.FormUrl,
                    OnboardingRequired = benefit.OnboardingRequired
                }
            };
        }
    }
}
