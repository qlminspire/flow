namespace Flow.Domain.Currencies;

public sealed record CurrencyCode : IValueObject
{
    public const int Length = 3;

    private CurrencyCode(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static Result<CurrencyCode> Create(string? value)
    {
        if (value is null)
            return Result.Failure<CurrencyCode>(Error.NullValueError);

        var code = string.Join(string.Empty, value.Where(char.IsLetter)).ToUpperInvariant();
        if (code.Length is not Length)
            return Result.Failure<CurrencyCode>(Error.ExactLengthError(Length));

        return new CurrencyCode(code);
    }
}