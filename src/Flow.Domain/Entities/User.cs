namespace Flow.Domain.Entities;

public sealed class User : BaseEntity, IHasDate
{
    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }
}
