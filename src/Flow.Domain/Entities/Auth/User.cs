namespace Flow.Domain.Entities.Auth;

public sealed class User : BaseEntity<Guid>, IHasDate
{

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTimeOffset? CreateDate { get; set; }

    public DateTimeOffset? UpdateDate { get; set; }
}
