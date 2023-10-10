namespace Flow.Api.Contracts.Responses.BankAccount;

public sealed class BankAccountResponse
{
    public Guid Id { get; set; }

    public string Iban { get; set; }

    public string Bank { get; set; }

    public decimal Amount { get; set; }

    public string Currency { get; set; }
}
