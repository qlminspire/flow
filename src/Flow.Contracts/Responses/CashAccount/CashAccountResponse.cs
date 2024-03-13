using Flow.Contracts.Responses.Currency;
using Flow.Contracts.Responses.UserCategory;

namespace Flow.Contracts.Responses.CashAccount;

public sealed record CashAccountResponse
{
    public required Guid Id { get; init; }

    public required string Name { get; init; }

    public required decimal Amount { get; init; }

    public required CurrencyShortResponse Currency { get; init; }

    public UserCategoryResponse? Category { get; init; }
}