namespace Flow.Domain.Currencies;

public sealed class Currency : Entity, IAuditable
{
    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}