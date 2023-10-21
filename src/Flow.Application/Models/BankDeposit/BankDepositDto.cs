using Flow.Application.Models.BankAccount;
using Flow.Application.Models.Currency;
using Flow.Domain.Enums;

namespace Flow.Application.Models.BankDeposit;

public sealed class BankDepositDto
{
    public Guid Id { get; set; }

    public decimal Amount { get; set; }

    public CurrencyDto Currency { get; set; }

    public DepositType Type { get; set; }

    public double Rate { get; set; }

    public int PeriodInMonths { get; set; }

    public DateTimeOffset? EndDate { get; set; }

    public BankAccountDto RefundAccount { get; set; }
}
