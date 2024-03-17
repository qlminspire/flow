namespace Flow.Domain.Abstractions;

public record Error(string Code, string Name)
{
    public static readonly Error None = new(string.Empty, string.Empty);

    public static readonly Error NullValueError = new("Common.NullValue", "Value must not be null");

    public static readonly Func<decimal, Error> MinValueError = value =>
        new Error("Common.LessThanMinValue", $"Value must be larger than {value}");

    public static readonly Func<decimal, Error> MaxValueError = value =>
        new Error("Common.GreaterThanMaxValue", $"Value must be less than {value}");

    public static readonly Func<int, Error> MinLengthError = length =>
        new Error("Common.LessThanMinLength", $"The length must be larger than {length}");

    public static readonly Func<int, Error> MaxLengthError = length =>
        new Error("Common.GreaterThanMaxLength", $"The length must be less than {length}");

    public static readonly Func<int, Error> ExactLengthError =
        length => new Error("Common.ExactLength", $"The length must be {length}");
}