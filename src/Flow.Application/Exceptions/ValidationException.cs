using FluentValidation.Results;

namespace Flow.Application.Exceptions;

[Serializable]
public class ValidationException : ApplicationException
{
    public IDictionary<string, string[]> Errors { get; } = new Dictionary<string, string[]>();

    public ValidationException() : base("One or more validation failures have occurred.")
    {
    }

    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        Errors = failures.GroupBy(x => x.PropertyName, x => x.ErrorMessage)
            .ToDictionary(x => x.Key, x => x.ToArray());
    }

    public ValidationException(string message) : base(message) { }

    public ValidationException(string message, Exception inner) : base(message, inner) { }
}
