namespace Flow.Domain.Users;

public sealed record UserId(Guid Value) : EntityId(Value);