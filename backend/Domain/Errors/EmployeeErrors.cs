namespace UDV_Benefits.Domain.Errors
{
    public class EmployeeErrors
    {
        public static Error EmployeeExists => new Error("Employee.Exists", "Такой сотрудник уже существует");
    }
}
