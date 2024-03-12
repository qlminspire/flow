namespace Flow.Domain.Users.Events;

public sealed record UserEmailChangedDomainEvent(UserId Id) : IDomainEvent;