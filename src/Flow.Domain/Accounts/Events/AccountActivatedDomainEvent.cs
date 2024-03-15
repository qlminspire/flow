namespace Flow.Domain.Accounts.Events;

public sealed record AccountActivatedDomainEvent(AccountId AccountId) : IDomainEvent;