namespace Flow.Business.Models.Balance;

public sealed class CalculatedBalanceDto
{
    public ICollection<BalanceDto> TotalBankAccounts { get; set; }

    public ICollection<BalanceDto> TotalCashAccounts { get; set; }

    public ICollection<BalanceDto> TotalDeposits { get; set; }
}
