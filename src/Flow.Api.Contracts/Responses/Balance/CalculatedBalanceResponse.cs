namespace Flow.Api.Contracts.Responses.Balance;

public sealed record CalculatedBalanceResponse
{
    public required ICollection<BalanceResponse> TotalBankAccounts { get; init; }

    public required ICollection<BalanceResponse> TotalCashAccounts { get; init; }

    public required ICollection<BalanceResponse> TotalDeposits { get; init; }

    public required ICollection<BalanceResponse> TotalDebts { get; init; }
}