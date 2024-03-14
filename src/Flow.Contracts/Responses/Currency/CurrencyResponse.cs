﻿namespace Flow.Contracts.Responses.Currency;

public sealed record CurrencyResponse
{
    public required Guid Id { get; init; }

    public required string Code { get; init; }

    public required bool IsDeactivated { get; init; }
}