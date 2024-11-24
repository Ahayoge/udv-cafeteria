using UDV_Benefits.Domain.DTO.Benefit.AddBenefit;
using UDV_Benefits.Domain.Models;

namespace UDV_Benefits.Domain.Mapper.BenefitMapper
{
    public static class AddBenefitMapper
    {
        public static Benefit FromDto(this AddBenefitRequest request)
        {
            return new Benefit
            {
                Name = request.Name,
                Description = request.Description,
                ValidityPeriodDays = request.ValidityPeriodDays,
                RealPrice = request.RealPrice,
                ExperienceYearsRequired = request.ExperienceYearsRequired,
                UcoinPrice = request.UcoinPrice,
                AdditionalInfo = request.AdditionalInfo,
                FormUrl = request.FormUrl,
                OnboardingRequired = request.OnboardingRequired
            };
        }

        public static AddBenefitResponse ToDto<T>(this Benefit benefit) where T : AddBenefitResponse
        {
            return new AddBenefitResponse
            {
                Id = benefit.Id,
                Name = benefit.Name,
                Category = benefit.Category.Name,
                Description = benefit.Description,
                ValidityPeriodDays = benefit.ValidityPeriodDays,
                RealPrice = benefit.RealPrice,
                ExperienceYearsRequired = benefit.ExperienceYearsRequired,
                UcoinPrice = benefit.UcoinPrice,
                AdditionalInfo = benefit.AdditionalInfo,
                FormUrl = benefit.FormUrl,
                OnboardingRequired = benefit.OnboardingRequired
            };
        }
    }
}
