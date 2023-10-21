namespace Flow.Api.Contracts.Responses.Currency;

public sealed record CurrencyResponse
{
    public required Guid Id { get; init; }

    public required string Code { get; init; }

    public required string Name { get; init; }

    public required bool IsActive { get; init; }
}