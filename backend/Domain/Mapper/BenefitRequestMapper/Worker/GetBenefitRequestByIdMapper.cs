using UDV_Benefits.Domain.DTO.Benefit.Worker.GetBenefitById;
using UDV_Benefits.Domain.DTO.BenefitRequest.Worker.BenefitRequestById;
using UDV_Benefits.Domain.Models;

namespace UDV_Benefits.Domain.Mapper.BenefitRequestMapper.Worker
{
    public static class GetBenefitRequestByIdMapper
    {
        public static GetBenefitRequestByIdResponse ToDto<T>(this BenefitRequest benefitRequest)
            where T : GetBenefitRequestByIdResponse
        {
            return new GetBenefitRequestByIdResponse
            {
                Id = benefitRequest.Id,
                Category = benefitRequest.Benefit.Category.Name,
                Status = benefitRequest.Status.ToString(),
                Name = benefitRequest.Benefit.Name,
                Description = benefitRequest.Benefit.Description,
                ValidityPeriodDays = benefitRequest.Benefit.ValidityPeriodDays,
                AdditionalInfo = benefitRequest.Benefit.AdditionalInfo,
                DmsProgram = benefitRequest.DmsProgram?.ToString(),
                RejectionReason = benefitRequest.RejectionReason,
                Conditions = new GetBenefitRequestByIdResponse.ConditionsDto
                {
                    ExperienceYearsRequired = benefitRequest.Benefit.ExperienceYearsRequired,
                    UcoinPrice = benefitRequest.Benefit.UcoinPrice,
                    FormRequired = benefitRequest.Benefit.FormRequired,
                    OnboardingRequired = benefitRequest.Benefit.OnboardingRequired
                }
            };
        }
    }
}
