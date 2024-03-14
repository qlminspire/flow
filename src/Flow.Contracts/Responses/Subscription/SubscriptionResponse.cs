﻿namespace Flow.Contracts.Responses.Subscription;

public sealed record SubscriptionResponse
{
    public required Guid Id { get; init; }

    public required string Name { get; init; }

    public required decimal Price { get; init; }

    public required string Currency { get; init; }

    public required int PaymentFrequencyMonths { get; init; }

    public required bool IsDeactivated { get; init; }
}