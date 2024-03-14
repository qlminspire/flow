﻿namespace Flow.Domain.Users;

public sealed record PasswordHash : IValueObject
{
    public const int MinLength = 3;
    public const int MaxLength = 512;

    private PasswordHash(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static Result<PasswordHash> Create(string? value)
    {
        if (value is null)
            return Result.Failure<PasswordHash>(Error.NullValue);

        var trimmedValue = value.Trim();
        if (trimmedValue.Length < MinLength)
            return Result.Failure<PasswordHash>(Error.LessThanMinValue);

        if (trimmedValue.Length > MaxLength)
            return Result.Failure<PasswordHash>(Error.GreaterThanMaxValue);

        return new PasswordHash(trimmedValue);
    }
}