using UDV_Benefits.Domain.Enums;

namespace UDV_Benefits.Domain.DTO.BenefitRequest.Worker.BenefitRequestById
{
    public class GetBenefitRequestByIdResponse
    {
        public class ConditionsDto
        {
            public int? ExperienceYearsRequired { get; set; } //TODO: стаж в виде "1 год 4 месяца"
            public int? UcoinPrice { get; set; }
            public bool FormRequired { get; set; }
            public bool OnboardingRequired { get; set; }
        }
        public Guid Id { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ValidityPeriodDays { get; set; }
        public ConditionsDto Conditions { get; set; }
        public string AdditionalInfo { get; set; }
        public string? DmsProgram { get; set; }
        public string? RejectionReason { get; set; }
    }
}
