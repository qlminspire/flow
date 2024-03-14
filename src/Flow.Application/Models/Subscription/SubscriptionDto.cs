namespace Flow.Application.Models.Subscription;

public sealed class SubscriptionDto
{
    public required Guid Id { get; init; }

    public required string Name { get; init; }

    public required decimal Price { get; init; }

    public required string Currency { get; init; }

    public required int PaymentFrequencyMonths { get; init; }

    public required bool IsDeactivated { get; init; }
}