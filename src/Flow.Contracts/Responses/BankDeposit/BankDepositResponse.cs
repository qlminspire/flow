using Flow.Contracts.Responses.Currency;
using Flow.Contracts.Responses.UserCategory;
using Flow.Domain.BankDeposits;

namespace Flow.Contracts.Responses.BankDeposit;

public sealed record BankDepositResponse
{
    public required Guid Id { get; init; }

    public required decimal Amount { get; init; }

    public required CurrencyShortResponse Currency { get; init; }

    public required DepositType Type { get; init; }

    public required double Rate { get; init; }

    public required int PeriodInMonths { get; init; }

    public UserCategoryResponse? Category { get; init; }
}