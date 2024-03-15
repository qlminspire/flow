namespace Flow.Domain.Accounts.Events;

public sealed record AccountDeactivatedDomainEvent(AccountId AccountId) : IDomainEvent;