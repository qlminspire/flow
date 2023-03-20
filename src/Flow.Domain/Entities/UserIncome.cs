namespace Flow.Domain.Entities;

public sealed class UserIncome : BaseEntity<Guid>, IHasDate
{
    public decimal Amount { get; set; }

    public IncomeSource Source { get; set; }

    public Guid AccountId { get; set; }

    public Account? Account { get; set; } = null!;

    public DateTimeOffset? Date { get; set; }

    public DateTimeOffset? CreateDate { get; set; }

    public DateTimeOffset? UpdateDate { get; set; }
}
