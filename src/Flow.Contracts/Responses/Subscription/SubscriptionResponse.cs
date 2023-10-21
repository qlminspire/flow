using Flow.Contracts.Responses.Currency;

namespace Flow.Contracts.Responses.Subscription;

public sealed record SubscriptionResponse
{
    public required Guid Id { get; init; }

    public required string Service { get; init; }

    public required decimal Price { get; init; }

    public required CurrencyShortResponse Currency { get; init; }

    public required bool IsActive { get; init; }
}
