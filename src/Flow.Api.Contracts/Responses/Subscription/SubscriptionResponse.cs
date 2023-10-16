using Flow.Api.Contracts.Responses.Currency;

namespace Flow.Api.Contracts.Responses.Subscription;

public sealed record SubscriptionResponse
{
    public Guid Id { get; init; }

    public string Service { get; init; }

    public decimal Price { get; init; }

    public CurrencyShortResponse Currency { get; init; }

    public bool IsActive { get; init; }
}
