namespace Flow.Domain.Abstractions;

public record Error(string Code, string Name)
{
    public static readonly Error None = new(string.Empty, string.Empty);

    public static readonly Error NullValue = new("Error.NullValue", "Null value was provided");

    public static readonly Error LessThanMinValue =
        new("Error.LessThanMinValue", "The provided value less than min value");

    public static readonly Error GreaterThanMaxValue =
        new("Error.GreaterThanMaxValue", "The provided value greater than max value");
}