
using Microsoft.EntityFrameworkCore;
using UDV_Benefits.Domain.Enums;
using UDV_Benefits.Infrastructure.Data;

namespace UDV_Benefits.Infrastructure
{
    public class StatusUpdateService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public StatusUpdateService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                    try
                    {
                        await dbContext.EmployeeBenefits
                            .Where(eb =>
                            eb.Status == EmployeeBenefitStatus.Active
                            && eb.DeactivatedWhen < DateOnly.FromDateTime(DateTime.Today))
                            .ForEachAsync(eb => eb.Status = EmployeeBenefitStatus.Expired, stoppingToken);

                        await dbContext.SaveChangesAsync(stoppingToken);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error occurred: {ex.Message}");
                    }
                }

                // Задаем интервал выполнения (например, раз в сутки)
                await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
            }
        }
    }
}
