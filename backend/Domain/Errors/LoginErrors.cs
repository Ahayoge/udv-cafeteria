namespace UDV_Benefits.Domain.Errors
{
    public static class LoginErrors
    {
        public static Error WrongCredentials { get; }
            = new Error("Login.WrongCredentials", "Неправильно введен email или пароль");
    }
}
