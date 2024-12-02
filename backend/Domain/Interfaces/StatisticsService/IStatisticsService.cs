using UDV_Benefits.Domain.Enums;
using UDV_Benefits.Domain.Models;

namespace UDV_Benefits.Domain.Interfaces.StatisticsService
{
    public interface IStatisticsService
    {
        public Task<StatisticsResult> GetStatisticsAsync(Guid benefitId, StatisticsPeriod period, int periodNumber, int year);
    }
}
