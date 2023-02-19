using Flow.Entities.Core;
using Flow.Entities.Core.Interfaces;

namespace Flow.Entities;

public sealed class UserCategory : BaseEntity<Guid>, IHasDate
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public Guid UserId { get; set; }

    public User? User { get; set; } = null!; 
     
    public DateTimeOffset? CreateDate { get; set; }

    public DateTimeOffset? UpdateDate { get; set; }
}
