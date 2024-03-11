using Flow.Domain.Users;

namespace Flow.Domain.UserCategories;

public sealed class UserCategory : Entity, IAuditable
{
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public Guid UserId { get; set; }

    public User? User { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }
}