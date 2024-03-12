namespace Flow.Domain.Abstractions;

public interface IDeactivatable
{
    bool IsDeactivated { get; }

    DateTime? DeactivatedAt { get; }
}