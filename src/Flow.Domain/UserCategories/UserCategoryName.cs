namespace Flow.Domain.UserCategories;

public sealed record UserCategoryName
{
    public const int MinLength = 3;
    public const int MaxLength = 64;

    private UserCategoryName(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static Result<UserCategoryName> Create(string? value)
    {
        if (value is null)
            return Result.Failure<UserCategoryName>(Error.NullValue);

        var trimmedValue = value.Trim();
        if (trimmedValue.Length < MinLength)
            return Result.Failure<UserCategoryName>(Error.LessThanMinValue);

        if (trimmedValue.Length > MaxLength)
            return Result.Failure<UserCategoryName>(Error.GreaterThanMaxValue);

        return new UserCategoryName(trimmedValue);
    }
}