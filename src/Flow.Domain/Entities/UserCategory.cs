using Flow.Domain.Entities.Auth;

namespace Flow.Domain.Entities;

public sealed class UserCategory : BaseEntity, IHasDate
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public Guid UserId { get; set; }

    public User? User { get; set; } = null!;

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }
}
