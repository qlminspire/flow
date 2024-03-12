namespace Flow.Domain.Subscriptions.Events;

public sealed record SubscriptionDeletedDomainEvent(SubscriptionId Id) : IDomainEvent;