namespace BookingHive.Application.Common.Models;

public class ValueResult<T> : Result
{
    public ValueResult(Result result, T? value = default)
        : base(result.Succeeded, result.Errors) =>
        Value = value;


    public ValueResult(bool succeeded, IEnumerable<string> errors, T? value = default)
        : base(succeeded, errors) =>
        Value = value;

    public T? Value { get; set; }

    public static ValueResult<T> Success(T value) =>
        new(Success(), value);
}
