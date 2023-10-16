namespace Flow.Api.Contracts.Responses.Balance;

public sealed record CalculatedBalanceResponse
{
    public ICollection<BalanceResponse> TotalBankAccounts { get; init; }

    public ICollection<BalanceResponse> TotalCashAccounts { get; init; }

    public ICollection<BalanceResponse> TotalDeposits { get; init; }

    public ICollection<BalanceResponse> TotalDebts { get; init; }
}