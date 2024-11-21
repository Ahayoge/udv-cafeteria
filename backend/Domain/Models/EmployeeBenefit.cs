using UDV_Benefits.Domain.Enums;

namespace UDV_Benefits.Domain.Models
{
    public class EmployeeBenefit
    {
        public Guid Id { get; set; }
        public EmployeeBenefitStatus Status { get; set; }
        public DateOnly ActivatedWhen { get; set; }
        public DateOnly DeactivatedWhen { get; set; }

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public Guid BenefitId { get; set; }
        public Benefit Benefit { get; set; }
    }
}
