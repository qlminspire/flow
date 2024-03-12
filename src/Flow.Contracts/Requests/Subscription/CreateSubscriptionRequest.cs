namespace Flow.Contracts.Requests.Subscription;

public sealed record CreateSubscriptionRequest
{
    public string? Name { get; init; }

    public decimal Price { get; init; }

    public Guid CurrencyId { get; init; }

    public int PaymentFrequencyMonths { get; init; }
}