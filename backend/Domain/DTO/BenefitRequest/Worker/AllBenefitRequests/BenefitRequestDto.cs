namespace UDV_Benefits.Domain.DTO.BenefitRequest.Worker.AllBenefitRequests
{
    public class BenefitRequestDto
    {
        //TODO: картинка
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateOnly StatusChangedWhen { get; set; }
    }
}
