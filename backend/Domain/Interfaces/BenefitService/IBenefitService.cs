using UDV_Benefits.Domain.Errors;
using UDV_Benefits.Domain.Models;

namespace UDV_Benefits.Domain.Interfaces.BenefitService
{
    public interface IBenefitService
    {
        public Task<List<Benefit>> GetAllBenefitsAsync();
        public Task<ValueResult<Benefit>> AddBenefitAsync(Benefit benefit);
        public Task<ValueResult<Benefit>> GetBenefitByIdWorkerAsync(Guid id);
        public Task<Result> ApplyForBenefitAsync(Employee employee, Benefit benefit);
    }
}
