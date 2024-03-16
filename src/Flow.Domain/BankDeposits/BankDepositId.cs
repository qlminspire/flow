namespace Flow.Domain.Banks;

public sealed record BankDepositId(Guid Value) : EntityId(Value);