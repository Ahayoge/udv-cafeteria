using UDV_Benefits.Domain.Enums;

namespace UDV_Benefits.Domain.Models
{
    public class EmployeeBenefit
    {
        public Guid Id { get; set; }
        public EmployeeBenefitStatus Status { get; set; }
        public DateOnly ActivatedWhen { get; set; }
        //TODO: дата деактивации может быть null
        public DateOnly DeactivatedWhen { get; set; } //TODO: синхронизировать со статусом

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public Guid BenefitId { get; set; }
        public Benefit Benefit { get; set; }
    }
}
