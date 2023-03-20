namespace Flow.Domain.Entities;

public sealed class User : BaseEntity<Guid>, IHasDate
{
    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTimeOffset? CreateDate { get; set; }

    public DateTimeOffset? UpdateDate { get; set; }
}
