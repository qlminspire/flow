namespace Flow.Api.Contracts.Requests.CashAccount;

public sealed record CreateCashAccountRequest(string Name, decimal Amount, Guid CurrencyId, Guid? CategoryId = null);