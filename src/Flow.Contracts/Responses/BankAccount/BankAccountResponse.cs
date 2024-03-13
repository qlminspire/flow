using Flow.Contracts.Responses.Bank;
using Flow.Contracts.Responses.Currency;
using Flow.Contracts.Responses.UserCategory;

namespace Flow.Contracts.Responses.BankAccount;

public sealed record BankAccountResponse
{
    public Guid Id { get; init; }

    public required string Iban { get; init; }

    public required BankShortResponse Bank { get; init; }

    public required decimal Amount { get; init; }

    public required CurrencyShortResponse Currency { get; init; }

    public UserCategoryResponse? Category { get; init; }
}