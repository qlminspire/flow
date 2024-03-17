namespace Flow.Domain.BankDeposits;

public sealed record BankDepositId(Guid Value) : EntityId(Value);