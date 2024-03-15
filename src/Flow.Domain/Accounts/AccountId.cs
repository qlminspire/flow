namespace Flow.Domain.Accounts;

public sealed record AccountId(Guid Value) : EntityId(Value);