namespace Flow.Api.Contracts.Responses.Currency;

public sealed record CurrencyResponse(Guid Id, string Code, string Name, bool IsActive);