namespace Flow.Domain.Shared;

public record Money : IValueObject
{
    public static readonly Error Negative = new("Money.Negative", "Money must not be negative");

    private Money(decimal value)
    {
        Value = value;
    }

    public decimal Value { get; private init; }

    public static Money Zero()
    {
        return new Money(0);
    }

    public bool IsZero()
    {
        return this == Zero();
    }

    public static Result<Money> Create(decimal value)
    {
        if (value < 0)
            return Result.Failure<Money>(Negative);

        return new Money(value);
    }

    public static Money operator +(Money first, Money second)
    {
        return first with { Value = first.Value + second.Value };
    }

    public static Money operator -(Money first, Money second)
    {
        return first with { Value = first.Value - second.Value };
    }

    public static Money operator *(Money first, Money second)
    {
        return first with { Value = first.Value * second.Value };
    }

    public static Money operator /(Money first, Money second)
    {
        return first with { Value = first.Value / second.Value };
    }

    public static bool operator >(Money first, Money second)
    {
        return first.Value > second.Value;
    }

    public static bool operator >=(Money first, Money second)
    {
        return first.Value >= second.Value;
    }

    public static bool operator <(Money first, Money second)
    {
        return first.Value < second.Value;
    }

    public static bool operator <=(Money first, Money second)
    {
        return first.Value <= second.Value;
    }
}