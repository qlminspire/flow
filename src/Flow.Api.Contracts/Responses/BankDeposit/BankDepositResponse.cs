using Flow.Api.Contracts.Responses.BankAccount;
using Flow.Api.Contracts.Responses.Currency;
using Flow.Api.Contracts.Responses.UserCategory;
using Flow.Domain.Enums;

namespace Flow.Api.Contracts.Responses.BankDeposit;

public sealed record BankDepositResponse
{
    public required Guid Id { get; init; }

    public required decimal Amount { get; init; }

    public required CurrencyShortResponse Currency { get; init; }

    public required DepositType Type { get; init; }

    public required double Rate { get; init; }

    public required int PeriodInMonths { get; init; }

    public required BankAccountResponse RefundAccount { get; init; }

    public UserCategoryShortResponse? Category { get; init; }
}