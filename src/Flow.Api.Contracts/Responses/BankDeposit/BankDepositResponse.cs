using Flow.Domain.Enums;

namespace Flow.Api.Contracts.Responses.BankDeposit;

public sealed class BankDepositResponse
{
    public Guid Id { get; set; }

    public decimal Amount { get; set; }

    public string Currency { get; set; }

    public DepositType Type { get; set; }

    public double Rate { get; set; }

    public int PeriodInMonthes { get; set; }

    public DateTimeOffset? EndDate { get; set; }
}