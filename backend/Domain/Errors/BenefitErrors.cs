namespace UDV_Benefits.Domain.Errors
{
    public class BenefitErrors
    {
        public static Error BenefitExists => new Error("Benefit.Exists", "Льгота с таким названием в выбранной категории уже существует");
    }
}
