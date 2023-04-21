namespace Flow.Application.Common;

public sealed class ValidationFailed
{
    public string Message { get; set; }

    public ValidationFailed(string message)
    {
        Message = message;
    }
}
