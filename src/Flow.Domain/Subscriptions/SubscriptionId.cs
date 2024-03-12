using Flow.Domain.Abstractions;

namespace Flow.Domain.Subscriptions;

public sealed record SubscriptionId(Guid Value) : EntityId(Value);