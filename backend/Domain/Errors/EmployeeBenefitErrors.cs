namespace UDV_Benefits.Domain.Errors
{
    public class EmployeeBenefitErrors
    {
        public static Error EmployeeBenefitIsActive => new Error(
            "EmployeeBenefit.IsActive", "Эта льгота сейчас активирована у вас");
        public static Error EmployeeBenefitNotFoundById => new Error(
            "EmployeeBenefit.NotFound", "Льгота с таким id не найдена у сотрудника");
        public static Error ActiveEmployeeBenefitNotFoundById => new Error(
            "EmployeeBenefit.NotFound", "Активная льгота с таким id не найдена у сотрудника");
    }
}
