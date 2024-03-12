namespace Flow.Domain.Currencies;

public sealed record CurrencyCode : IValueObject
{
    public const int Length = 3;

    private static readonly Error IncorrectLength =
        new("Error.IncorrectLength", "The provided string is not correct length");

    private CurrencyCode(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static Result<CurrencyCode> Create(string? value)
    {
        if (value is null)
            return Result.Failure<CurrencyCode>(Error.NullValue);

        var code = value.Trim().ToUpperInvariant();
        if (code.Length is not Length)
            return Result.Failure<CurrencyCode>(IncorrectLength);

        return new CurrencyCode(code);
    }
}