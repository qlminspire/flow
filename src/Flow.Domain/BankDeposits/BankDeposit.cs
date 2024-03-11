using Flow.Domain.Accounts;
using Flow.Domain.Currencies;
using Flow.Domain.UserCategories;
using Flow.Domain.Users;

namespace Flow.Domain.BankDeposits;

public sealed class BankDeposit : Entity, IAuditable
{
    public decimal Amount { get; set; }

    public Guid CurrencyId { get; set; }

    public Currency? Currency { get; set; }

    public Guid UserId { get; set; }

    public User? User { get; set; }

    public DepositType Type { get; set; }

    public double Rate { get; set; }

    public int PeriodInMonths { get; set; }

    public DateTimeOffset? EndDate { get; set; }

    public Guid RefundAccountId { get; set; }

    public BankAccount? RefundAccount { get; set; }

    public Guid? CategoryId { get; set; }

    public UserCategory? Category { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}