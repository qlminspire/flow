namespace Flow.Application.Models.Subscription;

public sealed class SubscriptionDto
{
    public Guid Id { get; init; }

    public string Name { get; init; }

    public decimal Price { get; init; }

    public string Currency { get; init; }

    public int PaymentFrequencyMonths { get; init; }

    public bool IsDeactivated { get; init; }
}