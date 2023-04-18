namespace Flow.Domain.Entities;

public sealed class UserPreferences : BaseEntity<Guid>, IHasDate
{
    public Guid PreferedCurrencyId { get; set; }

    public Currency PreferedCurrency { get; set; }

    public int BudgetingStartDay { get; set; }

    public DateTimeOffset? CreateDate { get; set; }

    public DateTimeOffset? UpdateDate { get; set; }
}
