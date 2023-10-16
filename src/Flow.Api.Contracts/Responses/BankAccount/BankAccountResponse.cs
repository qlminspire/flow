using Flow.Api.Contracts.Responses.Bank;
using Flow.Api.Contracts.Responses.Currency;
using Flow.Api.Contracts.Responses.UserCategory;

namespace Flow.Api.Contracts.Responses.BankAccount;

public sealed record BankAccountResponse
{
    public Guid Id { get; init; }

    public string Iban { get; init; }

    public BankShortResponse Bank { get; init; }

    public decimal Amount { get; init; }

    public CurrencyShortResponse Currency { get; init; }

    public UserCategoryShortResponse? Category { get; init; }
}
