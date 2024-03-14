namespace Flow.Application.Models.Balance;

public sealed class CalculatedBalanceDto
{
    public required ICollection<BalanceDto> TotalBankAccounts { get; init; }

    public required ICollection<BalanceDto> TotalCashAccounts { get; init; }

    public required ICollection<BalanceDto> TotalDeposits { get; init; }

    public required ICollection<BalanceDto> TotalDebts { get; init; }
}