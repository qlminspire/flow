namespace Flow.Domain.Entities;

public sealed class BankAccount : Account
{
    public string Iban { get; set; } = null!;

    public Guid BankId { get; set; }

    public Bank? Bank { get; set; }
}
