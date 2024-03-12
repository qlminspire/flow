namespace Flow.Domain.Shared;

public record Money : IValueObject
{
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

    public bool Positive()
    {
        return Value > 0;
    }

    public bool Negative()
    {
        return Value < 0;
    }

    public bool IsNegativeOrZero()
    {
        return Negative() || IsZero();
    }

    public static Result<Money> Create(decimal value)
    {
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