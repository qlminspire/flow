namespace Flow.Domain.Accounts;

public sealed record Iban : IValueObject
{
    public const int MinLength = 3;
    public const int MaxLength = 64;

    private Iban(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static Result<Iban> Create(string? value)
    {
        if (value is null)
            return Result.Failure<Iban>(Error.NullValue);

        var trimmedValue = value.Trim();
        if (trimmedValue.Length < MinLength)
            return Result.Failure<Iban>(Error.LessThanMinValue);

        if (trimmedValue.Length > MaxLength)
            return Result.Failure<Iban>(Error.GreaterThanMaxValue);

        return new Iban(trimmedValue);
    }
}