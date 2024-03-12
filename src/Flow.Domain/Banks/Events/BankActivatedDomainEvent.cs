namespace Flow.Domain.Banks.Events;

public sealed record BankActivatedDomainEvent(BankId Id) : IDomainEvent;