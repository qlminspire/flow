namespace Flow.Domain.Accounts.Events;

public sealed record AccountCreatedDomainEvent(AccountId AccountId) : IDomainEvent;