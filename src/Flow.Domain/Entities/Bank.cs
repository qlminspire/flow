namespace Flow.Domain.Entities;

public sealed class Bank : BaseEntity<Guid>, IHasDate
{
    public string Name { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTimeOffset? CreateDate { get; set; }

    public DateTimeOffset? UpdateDate { get; set; }
}
