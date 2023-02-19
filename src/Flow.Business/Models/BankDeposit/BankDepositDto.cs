using Flow.Business.Models.BankAccount;
using Flow.Entities.Core.Enums;

namespace Flow.Business.Models.BankDeposit;

public sealed class BankDepositDto
{
    public Guid Id { get; set; }

    public decimal Amount { get; set; }

    public string Currency { get; set; }

    public DepositType Type { get; set; }

    public double Rate { get; set; }

    public int PeriodInMonthes { get; set; }

    public DateTimeOffset? EndDate { get; set; }

    public BankAccountDto RefundAccount { get; set; }
}
