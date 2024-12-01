namespace UDV_Benefits.Domain.DTO.EmployeeBenefit.AllActive
{
    public class EmployeeBenefitDto
    {
        //TODO: картинка
        public Guid Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public DateOnly DeactivatedWhen { get; set; }
    }
}
