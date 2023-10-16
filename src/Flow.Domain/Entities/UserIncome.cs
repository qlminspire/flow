namespace Flow.Domain.Entities;

public sealed class UserIncome : BaseEntity, IAuditable
{
    public decimal Amount { get; set; }

    public IncomeSource Source { get; set; }

    public Guid AccountId { get; set; }

    public Account? Account { get; set; } = null!;

    public DateTimeOffset? Date { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }
}
