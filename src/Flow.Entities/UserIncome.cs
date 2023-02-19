using Flow.Entities.Core;
using Flow.Entities.Core.Enums;
using Flow.Entities.Core.Interfaces;

namespace Flow.Entities;

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
