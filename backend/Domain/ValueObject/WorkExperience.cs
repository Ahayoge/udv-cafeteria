namespace UDV_Benefits.Domain.ValueObject
{
    public class WorkExperience
    {
        public int Years { get; set; }
        public int Months { get; set; }

        public WorkExperience(int years, int months)
        {
            Years = years;
            Months = months;
        }

        public override string ToString() => $"{Years} год(а) {Months} месяц(ев)";
    }
}
