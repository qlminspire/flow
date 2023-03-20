namespace Flow.Application.Models.BankAccount;

public sealed record CreateBankAccountDto(string Iban, Guid BankId, decimal Amount, Guid CurrencyId, Guid? CategoryId = null);
