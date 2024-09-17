namespace Flow.Domain.Currencies.Events;

public sealed record CurrencyActivatedDomainEvent(CurrencyCode Code, DateTime ActivatedAt) : IDomainEvent;