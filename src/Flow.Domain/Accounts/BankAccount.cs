using Flow.Domain.BankDeposits;
using Flow.Domain.Banks;

namespace Flow.Domain.Accounts;

public sealed class BankAccount : Account
{
    public string Iban { get; set; }

    public Guid BankId { get; set; }

    public Bank? Bank { get; set; }

    public ICollection<BankDeposit> Deposits { get; set; }
}