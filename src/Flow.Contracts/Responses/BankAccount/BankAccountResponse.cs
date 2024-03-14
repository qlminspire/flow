namespace Flow.Contracts.Responses.BankAccount;

public sealed record BankAccountResponse
{
    public Guid Id { get; init; }

    public required string Name { get; init; }

    public required decimal Balance { get; init; }

    public required string Currency { get; init; }

    public string? Iban { get; init; }

    public required string Bank { get; init; }

    public string? Category { get; init; }
}