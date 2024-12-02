namespace UDV_Benefits.Domain.DTO.Statistics
{
    public class GetStatisticsRequest
    {
        public Guid BenefitId { get; set; }
        public string Period { get; set; }
    }
}
