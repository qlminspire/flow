namespace Flow.Domain.Entities;

public sealed class BankDeposit : BaseEntity<Guid>, IHasDate
{
    public decimal Amount { get; set; }

    public Guid CurrencyId { get; set; }

    public Currency? Currency { get; set; }

    public Guid UserId { get; set; }

    public User? User { get; set; }

    public Guid? CategoryId { get; set; }

    public UserCategory? Category { get; set; }

    public DepositType Type { get; set; }

    public double Rate { get; set; }

    public int PeriodInMonthes { get; set; }

    public DateTimeOffset? EndDate { get; set; }

    public Guid? RefundAccountId { get; set; }

    public BankAccount? RefundAccount { get; set; }

    public DateTimeOffset? CreateDate { get; set; }

    public DateTimeOffset? UpdateDate { get; set; }
}
