namespace Flow.Domain.Debts;

public sealed record DebtName : IValueObject
{
    public const int MinLength = 3;
    public const int MaxLength = 128;

    private DebtName(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static Result<DebtName> Create(string? value)
    {
        if (value is null)
            return Result.Failure<DebtName>(Error.NullValueError);

        var trimmedValue = value.Trim();
        if (trimmedValue.Length < MinLength)
            return Result.Failure<DebtName>(Error.MinLengthError(MinLength));

        if (trimmedValue.Length > MaxLength)
            return Result.Failure<DebtName>(Error.MaxLengthError(MaxLength));

        return new DebtName(trimmedValue);
    }
}