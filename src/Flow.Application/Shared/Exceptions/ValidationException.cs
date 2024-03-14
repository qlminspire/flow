namespace Flow.Application.Shared.Exceptions;

[Serializable]
public class ValidationException : ApplicationException
{
    public ValidationException(IEnumerable<ValidationError> errors)
    {
        Errors = errors;
    }

    public IEnumerable<ValidationError> Errors { get; }
}