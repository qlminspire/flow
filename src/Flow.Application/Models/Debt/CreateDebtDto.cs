namespace Flow.Application.Models.Debt;

public sealed record CreateDebtDto(string Name, decimal Amount, Guid CurrencyId);
