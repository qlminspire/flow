﻿namespace Flow.Api.Contracts.Responses.Balance;

public sealed class CalculatedBalanceResponse
{
    public ICollection<BalanceResponse> TotalBankAccounts { get; set; }

    public ICollection<BalanceResponse> TotalCashAccounts { get; set; }

    public ICollection<BalanceResponse> TotalDeposits { get; set; }

    public ICollection<BalanceResponse> TotalDebts { get; set; }
}