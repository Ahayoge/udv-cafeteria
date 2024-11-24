namespace UDV_Benefits.Domain.Errors
{
    public class Result
    {
        protected Result()
        {
            IsSuccess = true;
            Error = default;
        }

        protected Result(Error error)
        {
            IsSuccess = false;
            Error = error;
        }

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error? Error { get; } //TODO: список ошибок? мб использовать библиотеку FluentResults?

        public static implicit operator Result(Error error) =>
            new(error);

        public static Result Success() =>
            new();

        public static Result Failure(Error error) =>
            new(error);
    }
}
