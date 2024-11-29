using UDV_Benefits.Domain.DTO.Benefit.Worker.GetBenefitById;
using UDV_Benefits.Domain.Models;

namespace UDV_Benefits.Domain.Mapper.BenefitMapper
{
    public static class GetBenefitByIdMapper
    {
        public static GetBenefitByIdResponse ToDto<T>(this Benefit benefit) where T : GetBenefitByIdResponse
        {
            return new GetBenefitByIdResponse
            {
                Id = benefit.Id,
                Category = benefit.Category.Name,
                Name = benefit.Name,
                Description = benefit.Description,
                ValidityPeriodDays = benefit.ValidityPeriodDays,
                AdditionalInfo = benefit.AdditionalInfo,
                Conditions = new GetBenefitByIdResponse.ConditionsDto
                {
                    ExperienceYearsRequired = benefit.ExperienceYearsRequired,
                    UcoinPrice = benefit.UcoinPrice,
                    FormRequired = benefit.FormRequired,
                    OnboardingRequired = benefit.OnboardingRequired
                }
            };
        }
    }
}
