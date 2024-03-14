using Flow.Domain.BankDeposits;

namespace Flow.Application.Models.BankDeposit;

public sealed class BankDepositDto
{
    public required Guid Id { get; init; }

    public required decimal Amount { get; init; }

    public required string Currency { get; init; }

    public required DepositType Type { get; init; }

    public required double Rate { get; init; }

    public required int PeriodInMonths { get; init; }

    public required DateTimeOffset? EndDate { get; init; }
}