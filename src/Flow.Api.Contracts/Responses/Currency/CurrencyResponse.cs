namespace Flow.Api.Contracts.Responses.Currency;

public sealed record CurrencyResponse
{
    public Guid Id { get; init; }

    public string Code { get; init; }

    public string Name { get; init; }

    public bool IsActive { get; init; }
}