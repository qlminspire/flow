namespace Flow.Domain.Entities;

public sealed class Currency : BaseEntity, IHasDate
{
    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }
}
