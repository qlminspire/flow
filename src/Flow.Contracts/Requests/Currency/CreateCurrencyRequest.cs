namespace Flow.Contracts.Requests.Currency;

public sealed record CreateCurrencyRequest
{
    public string? Code { get; init; }

    public string? Name { get; init; }

    public bool IsActive { get; init; }
};
