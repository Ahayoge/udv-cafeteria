using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UDV_Benefits.Domain.DTO.Statistics;
using UDV_Benefits.Domain.Enums;
using UDV_Benefits.Domain.Interfaces.StatisticsService;
using UDV_Benefits.Domain.Mapper.StatisticsMapper;
using UDV_Benefits.Utilities;

namespace UDV_Benefits.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        [HttpPost]
        [Authorize(Policy = Policy.Admin)]
        public async Task<IActionResult> GetStatistics(GetStatisticsRequest statisticsRequest)
        {
            var period = (StatisticsPeriod)Enum.Parse(typeof(StatisticsPeriod), statisticsRequest.Period, true);
            var periodNumber = period == StatisticsPeriod.Month 
                ? DateTime.Now.Month
                : (period == StatisticsPeriod.Quarter 
                    ? (DateTime.Now.Month - 1) / 3 + 1
                    : 0);
            var year = DateTime.Now.Year;
            var statisticsResult = await _statisticsService
                .GetStatisticsAsync(statisticsRequest.BenefitId, period, periodNumber, year);
            var statisticsResultDto = statisticsResult.ToDto();
            return Ok(statisticsResultDto);
        }
    }
}
