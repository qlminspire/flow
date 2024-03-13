namespace Flow.Domain.PlannedExpenses;

public sealed record PlannedExpenseName : IValueObject
{
    public const int MinLength = 3;
    public const int MaxLength = 128;

    private PlannedExpenseName(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static Result<PlannedExpenseName> Create(string? value)
    {
        if (value is null)
            return Result.Failure<PlannedExpenseName>(Error.NullValue);

        var trimmedValue = value.Trim();

        if (trimmedValue.Length < MinLength)
            return Result.Failure<PlannedExpenseName>(Error.LessThanMinValue);

        if (trimmedValue.Length > MaxLength)
            return Result.Failure<PlannedExpenseName>(Error.GreaterThanMaxValue);

        return new PlannedExpenseName(value);
    }
}