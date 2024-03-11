namespace Flow.Application.Shared.Exceptions;

[Serializable]
public class ValidationException : ApplicationException
{
    public ValidationException(IEnumerable<ValidationError> errors)
    {
        Errors = errors;
    }

    [Obsolete("Remove after services migration")]
    public ValidationException(string message)
    {
        Errors = [];
    }

    [Obsolete("Remove after services migration")]
    public ValidationException()
    {
        Errors = [];
    }

    public IEnumerable<ValidationError> Errors { get; }
}