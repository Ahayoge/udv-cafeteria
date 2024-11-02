using UDV_Benefits.Domain.Models;

namespace UDV_Benefits.Domain.Interfaces.BenefitService
{
    public interface IBenefitService
    {
        public Task<List<Benefit>> GetAllBenefitsAsync();
    }
}
