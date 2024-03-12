namespace Flow.Contracts.Responses.Subscription;

public sealed class SubscriptionsMonthlyTotalResponse
{
    public decimal Amount { get; init; }

    public string Currency { get; init; }
}