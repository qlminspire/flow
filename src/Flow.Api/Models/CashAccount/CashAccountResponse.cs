﻿namespace Flow.Api.Models.CashAccount;

public sealed class CashAccountResponse
{
    public Guid Id { get; init; }

    public string Name { get; init; }

    public decimal Amount { get; init; }

    public string Currency { get; init; }
}
