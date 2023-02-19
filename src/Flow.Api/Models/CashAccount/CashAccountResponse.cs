namespace Flow.Api.Models.CashAccount;

public sealed class CashAccountResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public decimal Amount { get; set; }

    public string Currency { get; set; }
}
