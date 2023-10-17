using Flow.Api.Contracts.Responses.BankAccount;
using Flow.Api.Contracts.Responses.Currency;
using Flow.Api.Contracts.Responses.UserCategory;
using Flow.Domain.Enums;

namespace Flow.Api.Contracts.Responses.BankDeposit;

public sealed record BankDepositResponse
{
    public Guid Id { get; init; }

    public decimal Amount { get; init; }

    public CurrencyShortResponse Currency { get; init; }

    public DepositType Type { get; init; }

    public double Rate { get; init; }

    public int PeriodInMonths { get; init; }

    public BankAccountResponse RefundAccount { get; init; }

    public UserCategoryShortResponse Category { get; init; }
}