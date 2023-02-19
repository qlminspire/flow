namespace Flow.Business.Models.CashAccount;

public sealed record CreateCashAccountDto(string Name, decimal Amount, Guid CurrencyId, Guid? CategoryId = null);
