using Flow.Domain.Enums;

namespace Flow.Application.Models.BankDeposit;

public sealed record CreateBankDepositDto
{
    public decimal Amount { get; init; }

    public Guid CurrencyId { get; init; }

    public DepositType Type { get; init; }

    public double Rate { get; init; }

    public int PeriodInMonths { get; init; }

    public Guid RefundAccountId { get; init; }

    public Guid? CategoryId { get; init; }
}