namespace Flow.Domain.Accounts.Events;

public sealed record AccountDeletedDomainEvent(AccountId AccountId) : IDomainEvent;