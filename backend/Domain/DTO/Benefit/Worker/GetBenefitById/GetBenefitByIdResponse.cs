namespace UDV_Benefits.Domain.DTO.Benefit.Worker.GetBenefitById
{
    public class GetBenefitByIdResponse
    {
        public class ConditionsDto
        {
            public int? ExperienceYearsRequired { get; set; } //TODO: стаж в виде "1 год 4 месяца"
            public int? UcoinPrice { get; set; }
            public bool FormRequired { get; set; }
            public bool OnboardingRequired { get; set; }
        }

        public class ConditionsAreMetDto 
        {
            public bool? ExperienceYearsRequired { get; set; }
            public bool? UcoinPrice { get; set; }
            public bool? OnboardingRequired { get; set; }
        }

        //TODO: фото
        public Guid Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ValidityPeriodDays { get; set; }
        public ConditionsDto Conditions { get; set; }
        public string AdditionalInfo { get; set; }
        public ConditionsAreMetDto ConditionsAreMet { get; set; }
        public bool BenefitRequestExists { get; set; }
        public bool ActiveEmployeeBenefitExists { get; set; }
    }
}
