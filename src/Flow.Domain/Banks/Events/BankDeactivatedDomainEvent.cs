using Flow.Domain.Abstractions;

namespace Flow.Domain.Banks.Events;

public sealed record BankDeactivatedDomainEvent(BankId Id) : IDomainEvent;