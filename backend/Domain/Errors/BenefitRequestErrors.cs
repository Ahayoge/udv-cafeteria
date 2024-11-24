namespace UDV_Benefits.Domain.Errors
{
    public class BenefitRequestErrors
    {
        public static Error BenefitRequestExists => new Error(
            "BenefitRequest.Exists",
            "Нельзя подать новую заявку на льготу, пока предыдущая не рассмотрена");
        public static Error BenefitRequestNoAccessUcoins => new Error(
            "BenefitRequest.NoAccess",
            "Недостаточно юкоинов");
        public static Error BenefitRequestNoAccessExperience => new Error(
            "BenefitRequest.NoAccess",
            "Недостаточно стажа");
        public static Error BenefitRequestNoAccessOnboarding => new Error(
            "BenefitRequest.NoAccess",
            "Не пройден адаптационный период");
    }
}
