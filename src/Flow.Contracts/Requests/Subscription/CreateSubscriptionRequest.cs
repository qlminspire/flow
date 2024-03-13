namespace Flow.Contracts.Requests.Subscription;

public sealed record CreateSubscriptionRequest
{
    public string? Name { get; init; }

    public decimal Price { get; init; }

    public string? Currency { get; init; }

    public int PaymentFrequencyMonths { get; init; }
}