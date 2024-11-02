using UDV_Benefits.Domain.DTO.Benefit.AllBenefits;
using UDV_Benefits.Domain.Models;

namespace UDV_Benefits.Domain.Mapper
{
    public static class BenefitMapper
    {
        public static BenefitDto ToDto(this Benefit benefit)
        {
            return new BenefitDto
            {
                Id = benefit.Id,
                Name = benefit.Name,
                Description = benefit.Description,
                Conditions = new BenefitDto.ConditionsDto
                {
                    ExperienceYearsRequired = benefit.ExperienceYearsRequired,
                    UcoinPrice = benefit.UcoinPrice,
                    IsFormRequired = benefit.FormUrl != null
                }
            };
        }
    }
}
