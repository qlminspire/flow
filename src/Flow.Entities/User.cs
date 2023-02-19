using Flow.Entities.Core;
using Flow.Entities.Core.Interfaces;

namespace Flow.Entities;

public sealed class User : BaseEntity<Guid>, IHasDate
{
    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTimeOffset? CreateDate { get; set; }

    public DateTimeOffset? UpdateDate { get; set; }
}
