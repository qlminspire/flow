namespace Flow.Domain.Subscriptions;

public sealed record PaymentFrequencyMonths : IValueObject
{
    private const int OneMonth = 1;
    private const int TwoYears = 24;

    private static readonly Error LessThanOneMonthError = new("PaymentFrequencyMonths.LessThanOneMonth",
        "Payment frequency must be equal or larger than 1 month");

    private static readonly Error MoreThanTwoYearsError = new("PaymentFrequencyMonths.MoreThanTwoYears",
        "Payment frequency must be equal or less than 24 months");

    private PaymentFrequencyMonths(int value)
    {
        Value = value;
    }

    public int Value { get; private set; }

    public static Result<PaymentFrequencyMonths> Create(int value)
    {
        if (value < OneMonth)
            return Result.Failure<PaymentFrequencyMonths>(LessThanOneMonthError);

        if (value > TwoYears)
            return Result.Failure<PaymentFrequencyMonths>(MoreThanTwoYearsError);

        return new PaymentFrequencyMonths(value);
    }
}