namespace UDV_Benefits.Domain.Errors
{
    public class WorkerErrors
    {
        public static Error WorkerExists => new Error("Worker.Exists", "Такой сотрудник уже существует");
    }
}
