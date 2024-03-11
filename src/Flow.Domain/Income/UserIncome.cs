using Flow.Domain.Accounts;

namespace Flow.Domain.Income;

public sealed class UserIncome : Entity, IAuditable
{
    public decimal Amount { get; set; }

    public IncomeSource Source { get; set; }

    public Guid AccountId { get; set; }

    public Account? Account { get; set; } = null!;

    public DateTimeOffset? Date { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}