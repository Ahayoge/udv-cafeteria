using UDV_Benefits.Domain.Enums;

namespace UDV_Benefits.Domain.Models
{
    public class BenefitRequest
    {
        public Guid Id { get; set; }
        public DateOnly AppliedWhen { get; set; }
        //TODO: анкета
        public RequestStatus Status { get; set; }
        public DateOnly StatusChangedWhen { get; set; }
        public string? RejectionReason { get; set; }

        public Guid BenefitId {  get; set; }
        public Benefit Benefit { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DmsProgram? DmsProgram { get; set; }
    }
}
