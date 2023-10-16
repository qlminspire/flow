using Flow.Api.Contracts.Responses.Currency;
using Flow.Api.Contracts.Responses.UserCategory;

namespace Flow.Api.Contracts.Responses.CashAccount;

public sealed record CashAccountResponse
{
    public Guid Id { get; init; }

    public string Name { get; init; }

    public decimal Amount { get; init; }

    public CurrencyShortResponse Currency { get; init; }

    public UserCategoryShortResponse? Category { get; init; }
}
