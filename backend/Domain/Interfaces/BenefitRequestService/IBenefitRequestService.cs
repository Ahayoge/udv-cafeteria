using UDV_Benefits.Domain.Errors;
using UDV_Benefits.Domain.Models;

namespace UDV_Benefits.Domain.Interfaces.BenefitRequestService
{
    public interface IBenefitRequestService
    {
        public Task<Result> AddBenefitRequestAsync(BenefitRequest benefitRequest);
    }
}
