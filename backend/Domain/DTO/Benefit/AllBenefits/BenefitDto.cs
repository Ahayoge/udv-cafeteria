using Newtonsoft.Json;

namespace UDV_Benefits.Domain.DTO.Benefit.AllBenefits
{
    public class BenefitDto
    {
        public class ConditionsDto
        {
            public int? ExperienceYearsRequired { get; set; } //TODO: стаж в виде "1 год 4 месяца"
            public int? UcoinPrice { get; set; }
            public bool FormRequired { get; set; }
        }
        //TODO: фото
        public Guid Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ConditionsDto Conditions { get; set; }
    }
}
