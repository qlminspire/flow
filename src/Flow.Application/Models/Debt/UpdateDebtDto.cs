namespace Flow.Application.Models.Debt;

public sealed record UpdateDebtDto(string Name, decimal Amount, Guid CurrencyId);