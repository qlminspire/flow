using Flow.Api.Contracts.Responses.Bank;
using Flow.Api.Contracts.Responses.Currency;
using Flow.Api.Contracts.Responses.UserCategory;

namespace Flow.Api.Contracts.Responses.BankAccount;

public sealed record BankAccountResponse
{
    public Guid Id { get; init; }

    public required string Iban { get; init; }

    public required BankShortResponse Bank { get; init; }

    public required decimal Amount { get; init; }

    public required CurrencyShortResponse Currency { get; init; }

    public UserCategoryShortResponse? Category { get; init; }
}
