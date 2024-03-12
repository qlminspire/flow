namespace Flow.Domain.Subscriptions;

public sealed record PaymentFrequencyMonths : IValueObject
{
    private const int OneMonth = 1;
    private const int TwoYears = 24;

    public static readonly Error LessThanOneMonth = new("PaymentFrequencyMonths.LessThanOneMonth",
        "Payment frequency must be equal or larger than 1 month");

    public static readonly Error MoreThanTwoYears = new("PaymentFrequencyMonths.MoreThanTwoYears",
        "Payment frequency must be equal or less than 24 months");

    private PaymentFrequencyMonths(int value)
    {
        Value = value;
    }

    public int Value { get; private set; }

    public static Result<PaymentFrequencyMonths> Create(int value)
    {
        if (value < OneMonth)
            return Result.Failure<PaymentFrequencyMonths>(LessThanOneMonth);

        if (value > TwoYears)
            return Result.Failure<PaymentFrequencyMonths>(MoreThanTwoYears);

        return new PaymentFrequencyMonths(value);
    }
}