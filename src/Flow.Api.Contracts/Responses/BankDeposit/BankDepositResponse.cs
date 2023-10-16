using Flow.Api.Contracts.Responses.Currency;
using Flow.Domain.Enums;

namespace Flow.Api.Contracts.Responses.BankDeposit;

public sealed record BankDepositResponse
{
    public Guid Id { get; init; }

    public decimal Amount { get; init; }

    public CurrencyShortResponse Currency { get; init; }

    public DepositType Type { get; init; }

    public double Rate { get; init; }

    public int PeriodInMonthes { get; init; }

    public DateTimeOffset? EndDate { get; init; }
}