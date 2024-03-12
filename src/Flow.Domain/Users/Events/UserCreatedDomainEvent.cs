namespace Flow.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(UserId Id) : IDomainEvent;