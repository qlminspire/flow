namespace Flow.Domain.Entities;

public sealed class Currency : BaseEntity<Guid>, IHasDate
{
    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTimeOffset? CreateDate { get; set; }

    public DateTimeOffset? UpdateDate { get; set; }
}
