namespace Flow.Contracts.Requests.Subscription;

public sealed record CreateSubscriptionRequest
{
    public string? Service { get; init; }

    public decimal Price { get; init; }

    public Guid CurrencyId { get; init; }

    public bool IsActive { get; init; }
}