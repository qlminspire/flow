using Flow.Domain.Currencies;
using Flow.Domain.UserCategories;
using Flow.Domain.Users;

namespace Flow.Domain.Accounts;

public abstract class Account : Entity, IAuditable
{
    public decimal Amount { get; set; }

    public Guid CurrencyId { get; set; }

    public Currency? Currency { get; set; }

    public Guid UserId { get; set; }

    public User? User { get; set; }

    public Guid? CategoryId { get; set; }

    public UserCategory? Category { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}