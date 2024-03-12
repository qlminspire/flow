using Flow.Domain.Abstractions;

namespace Flow.Domain.Banks.Events;

public sealed record BankCreatedDomainEvent(BankId Id) : IDomainEvent;