namespace Flow.Api.Models.BankAccount;

public sealed record CreateBankAccountRequest(string Iban, Guid BankId, decimal Amount, Guid CurrencyId, Guid? CategoryId = null);