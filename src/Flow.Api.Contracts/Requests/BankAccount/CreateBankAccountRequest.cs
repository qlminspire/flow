namespace Flow.Api.Contracts.Requests.BankAccount;

public sealed record CreateBankAccountRequest(string Iban, Guid BankId, decimal Amount, Guid CurrencyId, Guid? CategoryId = null);