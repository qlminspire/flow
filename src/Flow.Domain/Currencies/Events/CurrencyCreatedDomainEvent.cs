namespace Flow.Domain.Currencies.Events;

public sealed record CurrencyCreatedDomainEvent(CurrencyCode Code, DateTime CreatedAt) : IDomainEvent;