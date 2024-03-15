namespace Flow.Domain.Accounts.Events;

public sealed record WithdrawalCreatedDomainEvent(AccountId SourceAccountId, AccountId TargetAccountId) : IDomainEvent;