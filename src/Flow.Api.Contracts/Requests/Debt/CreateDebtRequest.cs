namespace Flow.Api.Contracts.Requests.Debt;

public sealed record CreateDebtRequest(string Name, decimal Amount, Guid CurrencyId);
