namespace Flow.Api.Models.Balance;

public sealed class CalculatedBalanceResponse
{
    public ICollection<BalanceResponse> TotalBankAccounts { get; set; }

    public ICollection<BalanceResponse> TotalCashAccounts { get; set; }

    public ICollection<BalanceResponse> TotalDeposits { get; set; }
}