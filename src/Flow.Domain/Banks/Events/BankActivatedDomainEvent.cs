using Flow.Domain.Abstractions;

namespace Flow.Domain.Banks.Events;

public sealed record BankActivatedDomainEvent(BankId Id) : IDomainEvent;