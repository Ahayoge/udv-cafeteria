using UDV_Benefits.Domain.DTO.Benefit.Statistics;
using UDV_Benefits.Domain.Models;

namespace UDV_Benefits.Domain.Mapper.BenefitMapper
{
    public static class AllStatisticsMapper
    {
        public static IEnumerable<ChosenBenefitStatisticsDto> ToDto(this List<Benefit> benefits)
        {
            return benefits.Select(benefit => new ChosenBenefitStatisticsDto
            {
                Id = benefit.Id,
                Name = benefit.Name
            });
        }
    }
}
