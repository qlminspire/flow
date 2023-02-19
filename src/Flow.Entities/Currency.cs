using Flow.Entities.Core;
using Flow.Entities.Core.Interfaces;

namespace Flow.Entities;

public sealed class Currency : BaseEntity<Guid>, IHasDate
{
    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTimeOffset? CreateDate { get; set; }

    public DateTimeOffset? UpdateDate { get; set; }
}
