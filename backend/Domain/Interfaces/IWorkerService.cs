using UDV_Benefits.Domain.Errors;
using UDV_Benefits.Domain.Models;
using UDV_Benefits.Infrastructure.Data;

namespace UDV_Benefits.Domain.Interfaces
{
    public interface IWorkerService
    {
        public Task<Result> AddWorkerAsync(Worker worker);
    }
}
