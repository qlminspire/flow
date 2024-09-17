namespace Flow.Domain.Currencies.Events;

public sealed record CurrencyDeactivatedDomainEvent(CurrencyCode Code, DateTime DeactivatedAt) : IDomainEvent;