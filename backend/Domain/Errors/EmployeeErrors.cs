namespace UDV_Benefits.Domain.Errors
{
    public class EmployeeErrors
    {
        public static Error EmployeeExists => new Error("Employee.Exists", "Такой сотрудник уже существует");
        public static Error EmployeeNotFoundByUserId => 
            new Error("Employee.NotFound", "Сотрудника с таким userId не существует");
    }
}
