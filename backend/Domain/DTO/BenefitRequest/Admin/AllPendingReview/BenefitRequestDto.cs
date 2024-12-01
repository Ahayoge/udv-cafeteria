namespace UDV_Benefits.Domain.DTO.BenefitRequest.Admin.AllPendingReview
{
    public class BenefitRequestDto
    {
        public class EmployeeDto
        {
            public string FirstName { get; set; }
            public string Patronymic { get; set; }
            public string LastName { get; set; }
        }
        public Guid Id {  get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public EmployeeDto Employee {  get; set; }
        public DateOnly AppliedWhen { get; set; }
    }
}
