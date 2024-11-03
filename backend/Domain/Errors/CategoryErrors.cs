namespace UDV_Benefits.Domain.Errors
{
    public static class CategoryErrors
    {
        public static Error CategoryDoesntExist => new Error("Category.DoesntExist", "Такой категории не существует");
    }
}
