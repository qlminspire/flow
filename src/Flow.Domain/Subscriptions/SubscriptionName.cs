namespace Flow.Domain.Subscriptions;

public sealed record SubscriptionName : IValueObject
{
    public const int MinLength = 3;
    public const int MaxLength = 64;

    private SubscriptionName(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static Result<SubscriptionName> Create(string? value)
    {
        if (value is null)
            return Result.Failure<SubscriptionName>(Error.NullValue);

        var trimmedValue = value.Trim();
        if (trimmedValue.Length < MinLength)
            return Result.Failure<SubscriptionName>(Error.LessThanMinValue);

        if (trimmedValue.Length > MaxLength)
            return Result.Failure<SubscriptionName>(Error.GreaterThanMaxValue);

        return new SubscriptionName(trimmedValue);
    }
}