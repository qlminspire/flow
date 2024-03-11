namespace Flow.Application.Shared.Exceptions;

[Serializable]
public class NotFoundException : ApplicationException
{
    public NotFoundException()
    {
    }

    public NotFoundException(string message)
        : base(message)
    {
    }

    public NotFoundException(string name, string key)
        : base($"Entity \"{name}\" ({key}) not found.")
    {
    }

    public NotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }
}