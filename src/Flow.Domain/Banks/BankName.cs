namespace Flow.Domain.Banks;

public sealed record BankName : IValueObject
{
    public const int MinLength = 3;
    public const int MaxLength = 64;

    private BankName(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static Result<BankName> Create(string? value)
    {
        if (value is null)
            return Result.Failure<BankName>(Error.NullValueError);

        var trimmedValue = value.Trim();
        if (trimmedValue.Length < MinLength)
            return Result.Failure<BankName>(Error.MinLengthError(MinLength));

        if (trimmedValue.Length > MaxLength)
            return Result.Failure<BankName>(Error.MaxLengthError(MaxLength));

        return new BankName(trimmedValue);
    }
}