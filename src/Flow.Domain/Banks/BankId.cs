namespace Flow.Domain.Banks;

public sealed record BankId(Guid Value) : EntityId(Value);