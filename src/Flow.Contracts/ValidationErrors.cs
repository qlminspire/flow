namespace Flow.Contracts;

public sealed class ValidationErrors
{
    public required ICollection<ValidationErrorDetails> Errors { get; init; }
}