namespace Flow.Api.Models.Debt;

public sealed record CreateDebtRequest(string Name, decimal Amount, Guid CurrencyId);
