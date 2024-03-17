namespace Flow.Domain.Abstractions;

public record Error(string Code, string Message)
{
    public static readonly Error None = new(string.Empty, string.Empty);

    public static readonly Error NullValueError = new("Common.NullValue", "The value must not be null");

    public static readonly Error DefaultValueError = new("Common.DefaultValue", "The value must not be default one");

    public static readonly Func<decimal, Error> MinValueError = value =>
        new Error("Common.LessThanMinValue", $"The value must be larger than {value}");

    public static readonly Func<decimal, Error> MaxValueError = value =>
        new Error("Common.GreaterThanMaxValue", $"The value must be less than {value}");

    public static readonly Func<int, Error> MinLengthError = length =>
        new Error("Common.LessThanMinLength", $"The length must be larger than {length}");

    public static readonly Func<int, Error> MaxLengthError = length =>
        new Error("Common.GreaterThanMaxLength", $"The length must be less than {length}");

    public static readonly Func<int, Error> ExactLengthError =
        length => new Error("Common.ExactLength", $"The length must be {length}");
}