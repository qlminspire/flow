namespace Flow.Application.Models.Subscription;

public sealed record CreateSubscriptionDto
{
    public string Service { get; init; }

    public decimal Price { get; init; }

    public Guid CurrencyId { get; init; }

    public bool IsActive { get; init; }
}