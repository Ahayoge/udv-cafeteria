using Microsoft.EntityFrameworkCore;
using UDV_Benefits.Domain.Errors;
using UDV_Benefits.Domain.Interfaces;
using UDV_Benefits.Domain.Models;
using UDV_Benefits.Infrastructure.Data;

namespace UDV_Benefits.Services
{
    public class WorkerService : IWorkerService
    {
        private readonly AppDbContext _dbContext;

        public WorkerService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result> AddWorkerAsync(Worker worker)
        {
            var existingWorker = await _dbContext.Workers
                .FirstOrDefaultAsync(w 
                => w.FirstName == worker.FirstName 
                && w.Patronymic == worker.Patronymic
                && w.LastName == worker.LastName
                && w.BirthDate == worker.BirthDate);
            if (existingWorker != null)
            {
                return WorkerErrors.WorkerExists;
            }

            _dbContext.Workers.Add(worker);
            return Result.Success();
        }
    }
}
