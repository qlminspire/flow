namespace Flow.Domain.Accounts.Events;

public sealed record DepositCreatedDomainEvent(AccountId SourceAccountId, AccountId TargetAccountId) : IDomainEvent;