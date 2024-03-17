using System.Text.RegularExpressions;

namespace Flow.Domain.Users;

public sealed record Email : IValueObject
{
    public const int MaxLength = 256;

    private static readonly Regex EmailRegex =
        new(@"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", RegexOptions.Compiled);

    private static readonly Error InvalidEmailError = new("Email.InvalidEmail", "The provided email does not valid");

    private Email(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static Result<Email> Create(string? value)
    {
        if (value is null)
            return Result.Failure<Email>(Error.NullValueError);

        var email = value.Trim();
        if (value.Length > MaxLength)
            return Result.Failure<Email>(Error.MaxLengthError(MaxLength));

        if (!EmailRegex.IsMatch(email))
            return Result.Failure<Email>(InvalidEmailError);

        return new Email(value);
    }
}