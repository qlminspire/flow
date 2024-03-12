namespace Flow.Contracts.Requests.Currency;

public sealed record CreateCurrencyRequest
{
    public string? Code { get; init; }
}