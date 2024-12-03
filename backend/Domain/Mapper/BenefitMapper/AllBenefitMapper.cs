using UDV_Benefits.Domain.DTO.Benefit.AddBenefit;
using UDV_Benefits.Domain.DTO.Benefit.AllBenefits;
using UDV_Benefits.Domain.Models;

namespace UDV_Benefits.Domain.Mapper.BenefitMapper
{
    public static class AllBenefitMapper
    {
        public static BenefitDto ToDto<T>(this Benefit benefit) where T: BenefitDto
        {
            return new BenefitDto
            {
                Id = benefit.Id,
                Category = benefit.Category.Name,
                Name = benefit.Name,
                Conditions = new BenefitDto.ConditionsDto
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
