using System.Text.Json.Serialization;

namespace UDV_Benefits.Domain.Errors
{
    public class ValueResult<TValue>: Result
    {
        private readonly TValue? _value;

        private ValueResult(
            TValue value
        ) : base()
        {
            _value = value;
        }

        private ValueResult(
            Error error
        ) : base(error)
        {
            _value = default;
        }

        public TValue Value =>
            IsSuccess ? _value! : throw new InvalidOperationException("Value can not be accessed when IsSuccess is false");

        public static implicit operator ValueResult<TValue>(Error error) =>
            new(error);

        public static implicit operator ValueResult<TValue>(TValue value) =>
            new(value);

        public static ValueResult<TValue> Success(TValue value) =>
            new(value);

        public new static ValueResult<TValue> Failure(Error error) =>
            new(error);
    }

}
