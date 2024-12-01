using UDV_Benefits.Domain.Errors;
using UDV_Benefits.Domain.Models;

namespace UDV_Benefits.Domain.Interfaces.BenefitRequestService
{
    public interface IBenefitRequestService
    {
        public Task<Result> AddBenefitRequestAsync(BenefitRequest benefitRequest);
        public Task<List<BenefitRequest>> GetBenefitRequestsByEmployeeIdAsync(Guid employeeId);
        public Task<Result> RejectBenefitRequestByIdAsync(Guid benefitRequestId, string reason);
        public Task<Result> ApproveBenefitRequestByIdAsync(Guid benefitRequestId);
        public Task<List<BenefitRequest>> GetAllPendingReviewBenefitRequestsAsync();
    }
}
