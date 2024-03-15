namespace Flow.Domain.Abstractions;

public interface IAuditable
{
    DateTime CreatedAt { get; }

    DateTime? UpdatedAt { get; }
}