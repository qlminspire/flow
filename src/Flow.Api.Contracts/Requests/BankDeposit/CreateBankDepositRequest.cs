using Flow.Domain.Enums;

namespace Flow.Api.Contracts.Requests.BankDeposit;

public sealed record CreateBankDepositRequest
{
    public decimal Amount { get; init; }

    public Guid CurrencyId { get; init; }

    public double Rate { get; init; }

    public DepositType Type { get; init; }

    public int PeriodInMonthes { get; init; }

    public Guid? RefundAccountId { get; init; }
}
