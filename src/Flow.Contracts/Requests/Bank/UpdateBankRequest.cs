namespace Flow.Contracts.Requests.Bank;

public sealed record UpdateBankRequest(string?
    Name, bool IsActive);