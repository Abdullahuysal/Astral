namespace Astral.Membership.Core.Shared
{
    public class Result : IResult
    {
        protected internal Result(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None ||
                !isSuccess && error == Error.None)
            {
                throw new ArgumentException("Invalid Error", nameof(error));
            }

            IsSuccess = isSuccess;
            Error = error;
        }
        public bool IsSuccess { get; }
        public Error Error { get; }
        public static Result Success() => new(true, Error.None);
        public static Result<T> Success<T>(T value) => new(value, true, Error.None);
        public static Result Failure(Error error) => new(false, error);
        public static Result<T> Failure<T>(Error error) => new Result<T>(default, false, error);
        public static Result<T> Create<T>(T value) => value is not null ? Success(value) : Failure<T>(Error.NullValue);

    }

    public class Result<T> : Result
    {
        private readonly T? _value;
        protected internal Result(T? value, bool isSuccess,  Error error) : base(isSuccess, error) => _value = value;

        public T? Value => IsSuccess ? _value : throw new InvalidOperationException("There is no value for a failed result.");

        public static implicit operator Result<T>(T value) => Create(value);

    }
}
