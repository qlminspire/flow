namespace Flow.Application.Models.Balance;

public sealed class CalculatedBalanceDto
{
    public ICollection<BalanceDto> TotalBankAccounts { get; set; }

    public ICollection<BalanceDto> TotalCashAccounts { get; set; }

    public ICollection<BalanceDto> TotalDeposits { get; set; }

    public ICollection<BalanceDto> TotalDebts { get; set; }
}
