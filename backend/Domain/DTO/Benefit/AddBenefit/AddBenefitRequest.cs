namespace UDV_Benefits.Domain.DTO.Benefit.AddBenefit
{
    public class AddBenefitRequest
    {
        //TODO: добавить картинку
        public string Name {  get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int ValidityPeriodDays { get; set; }
        public int RealPrice { get; set; }
        public int? ExperienceYearsRequired { get; set; } //TODO: стаж в виде "1 год 4 месяца", value object WorkExperience
        public int? UcoinPrice { get; set; }
        public string AdditionalInfo { get; set; }
        public string? FormUrl { get; set; }
        public bool OnboardingRequired { get; set; }
    }
}
