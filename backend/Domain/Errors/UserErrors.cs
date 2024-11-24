namespace UDV_Benefits.Domain.Errors
{
    public class UserErrors
    {
        public static Error UserNotFound => new Error("User.NotFound", "Пользователь не найден");
        public static Error UserNotFoundById => new Error("User.NotFound", "Пользователь с таким id не найден");
        public static Error WrongPassword => new Error("User.WrongPassword", "Неверный пароль");
        public static Error UserExists => new Error("User.Exists", "Пользователь с такими данными уже существует");
    }
}
