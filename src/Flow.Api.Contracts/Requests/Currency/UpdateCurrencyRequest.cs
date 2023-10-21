namespace Flow.Api.Contracts.Requests.Currency;

public sealed record UpdateCurrencyRequest(string? Code, string? Name, bool IsActive);
