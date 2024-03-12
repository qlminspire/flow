namespace Flow.Contracts.Responses.Currency;

public sealed record CurrencyResponse
{
    public Guid Id { get; init; }

    public string? Code { get; init; }

    public bool IsDeactivated { get; init; }
}