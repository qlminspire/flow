using Flow.Domain.Enums;

namespace Flow.Contracts.Requests.BankDeposit;

public sealed record CreateBankDepositRequest
{
    public decimal Amount { get; init; }

    public Guid CurrencyId { get; init; }

    public DepositType Type { get; init; }

    public double Rate { get; init; }

    public int PeriodInMonths { get; init; }

    public Guid RefundAccountId { get; init; }

    public Guid? CategoryId { get; init; }
}