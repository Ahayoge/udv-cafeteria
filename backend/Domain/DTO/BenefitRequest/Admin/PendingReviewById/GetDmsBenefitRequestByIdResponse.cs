namespace UDV_Benefits.Domain.DTO.BenefitRequest.Admin.PendingReviewById
{
    public class GetDmsBenefitRequestByIdResponse
    {
        public Guid Id {  get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string DmsProgram { get; set; }
    }
}
