﻿namespace Flow.Api.Contracts.Responses.Debt;

public sealed class DebtResponse
{
    public Guid Id { get; init; }

    public string Name { get; init; }

    public decimal Amount { get; init; }

    public string Currency { get; init; }
}