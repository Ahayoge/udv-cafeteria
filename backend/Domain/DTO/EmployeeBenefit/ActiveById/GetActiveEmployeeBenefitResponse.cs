namespace UDV_Benefits.Domain.DTO.EmployeeBenefit.ActiveById
{
    public class GetActiveEmployeeBenefitResponse
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
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly DeactivatedWhen { get; set; }
        public string AdditionalInfo { get; set; }
        public ConditionsDto Conditions { get; set; }
        public string? DmsProgram { get; set; }
    }
}
