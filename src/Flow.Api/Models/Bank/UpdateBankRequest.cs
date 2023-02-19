namespace Flow.Api.Models.Bank;

public sealed record UpdateBankRequest(string Name, bool IsActive);