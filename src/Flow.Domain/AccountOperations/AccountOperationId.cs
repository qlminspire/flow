namespace Flow.Domain.AccountOperations;

public sealed record AccountOperationId(Guid Value) : EntityId(Value);