namespace UDV_Benefits.Domain.Errors
{
    public class UserErrors
    {
        public static Error UserNotFound => new Error("User.NotFound", "Пользователь не найден");
        public static Error WrongPassword => new Error("User.WrongPassword", "Неверный пароль");
        public static Error UserExists => new Error("User.Exists", "Пользователь с таким email уже существует");
    }
}
