namespace UDV_Benefits.Domain.Errors
{
    public class EmployeeBenefitErrors
    {
        public static Error EmployeeBenefitIsActive => new Error(
            "EmployeeBenefit.IsActive", "Эта льгота сейчас активирована у вас");
    }
}
