namespace Flow.Application.Models.BankAccount;

public sealed record UpdateBankAccountDto(decimal Amount, Guid CurrencyId, Guid? CategoryId = null);
