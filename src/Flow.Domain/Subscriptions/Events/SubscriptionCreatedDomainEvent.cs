namespace Flow.Domain.Subscriptions.Events;

public sealed record SubscriptionCreatedDomainEvent(SubscriptionId Id) : IDomainEvent;