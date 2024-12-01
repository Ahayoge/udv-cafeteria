using UDV_Benefits.Domain.DTO.BenefitRequest.Worker.AllBenefitRequests;
using UDV_Benefits.Domain.Models;

namespace UDV_Benefits.Domain.Mapper.BenefitRequestMapper
{
    public static class AllBenefitRequestsMapper
    {
        public static BenefitRequestDto ToDto<T>(this BenefitRequest benefitRequest) where T : BenefitRequestDto
        {
            return new BenefitRequestDto
            {
                //TODO: картинка
                Id = benefitRequest.Id,
                Category = benefitRequest.Benefit.Category.Name,
                Name = benefitRequest.Benefit.Name,
                Status = benefitRequest.Status.ToString(),
                StatusChangedWhen = benefitRequest.StatusChangedWhen
            };
        }
    }
}
