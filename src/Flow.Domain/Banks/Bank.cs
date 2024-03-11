namespace Flow.Domain.Banks;

public sealed class Bank : Entity, IAuditable
{
    public string Name { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }
}