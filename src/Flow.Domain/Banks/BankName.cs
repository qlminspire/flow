namespace Flow.Domain.Banks;

public sealed record BankName : IValueObject
{
    public const int MinLength = 3;
    public const int MaxLength = 64;

    public static readonly Error NullOrWhiteSpace = new("BankName.NullOrWhiteSpace", "Bank name is null or empty");

    public static readonly Error OutOfLimit =
        new("BankName.OutOfLimit", $"Bank name must be between {MinLength} and {MaxLength} characters");

    private BankName(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static Result<BankName> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result.Failure<BankName>(NullOrWhiteSpace);

        if (value.Length is < MinLength or > MaxLength)
            return Result.Failure<BankName>(OutOfLimit);

        return new BankName(value);
    }
}