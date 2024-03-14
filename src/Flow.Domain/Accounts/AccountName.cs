namespace Flow.Domain.Accounts;

public sealed record AccountName : IValueObject
{
    public const int MinLength = 3;
    public const int MaxLength = 64;

    private AccountName(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static Result<AccountName> Create(string? value)
    {
        if (value is null)
            return Result.Failure<AccountName>(Error.NullValue);

        var trimmedValue = value.Trim();
        if (trimmedValue.Length < MinLength)
            return Result.Failure<AccountName>(Error.LessThanMinValue);

        if (trimmedValue.Length > MaxLength)
            return Result.Failure<AccountName>(Error.GreaterThanMaxValue);

        return new AccountName(trimmedValue);
    }
}