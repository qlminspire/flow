using Flow.Domain.Abstractions;

namespace Flow.Application.Shared.Exceptions;

[Serializable]
public class NotFoundException : ApplicationException
{
    public NotFoundException()
    {
    }

    public NotFoundException(Guid key)
        : base($"Entity {key} not found")
    {
    }

    public NotFoundException(EntityId key)
        : base($"Entity {key.Value} not found")
    {
    }
}