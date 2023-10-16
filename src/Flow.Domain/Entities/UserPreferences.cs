namespace Flow.Domain.Entities;

public sealed class UserPreferences : BaseEntity, IHasDate
{
    public Guid CurrencyId { get; set; }

    public Currency? Currency { get; set; }

    public int BudgetingStartDay { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }
}
