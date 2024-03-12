namespace Flow.Application.Models.Subscription;

public sealed record CreateSubscriptionDto
{
    public string? Name { get; init; }

    public decimal Price { get; init; }

    public Guid CurrencyId { get; init; }

    public int PaymentFrequencyMonths { get; init; }
}