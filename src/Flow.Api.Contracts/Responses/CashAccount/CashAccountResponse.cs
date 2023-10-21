using Flow.Api.Contracts.Responses.Currency;
using Flow.Api.Contracts.Responses.UserCategory;

namespace Flow.Api.Contracts.Responses.CashAccount;

public sealed record CashAccountResponse
{
    public required Guid Id { get; init; }

    public required string Name { get; init; }

    public required decimal Amount { get; init; }

    public required CurrencyShortResponse Currency { get; init; }

    public UserCategoryShortResponse? Category { get; init; }
}
