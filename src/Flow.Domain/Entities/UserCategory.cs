namespace Flow.Domain.Entities;

public sealed class UserCategory : BaseEntity, IAuditable
{
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public Guid UserId { get; set; }

    public User? User { get; set; } = null!;

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }
}
