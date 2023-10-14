using System.Reflection;

using Microsoft.EntityFrameworkCore;

using Flow.Domain.Common;

namespace Flow.Infrastructure.Persistence;

public class FlowContext : DbContext
{
    public FlowContext(DbContextOptions<FlowContext> options) : base(options)
    {
    }

    public DbSet<Account> Accounts { get; set; } = default!;

    public DbSet<AccountOperation> AccountOperations { get; set; } = default!;

    public DbSet<Bank> Banks { get; set; } = default!;

    public DbSet<BankAccount> BankAccounts { get; set; } = default!;

    public DbSet<BankDeposit> BankDeposits { get; set; } = default!;

    public DbSet<CashAccount> CashAccounts { get; set; } = default!;

    public DbSet<Currency> Currencies { get; set; } = default!;

    public DbSet<Subscription> Subscriptions { get; set; } = default!;

    public DbSet<User> Users { get; set; } = default!;

    public DbSet<UserCategory> UserCategories { get; set; } = default!;

    public DbSet<UserIncome> UserIncomes { get; set; } = default!;

    public DbSet<PlannedExpense> PlannedExpenses { get; set; } = default!;

    public DbSet<UserPreferences> UserPreferences { get; set; } = default!;

    public DbSet<Debt> Debts { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(FlowContext))!);
        base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
        UpdateEntityDates();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateEntityDates();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateEntityDates()
    {
        var entries = ChangeTracker.Entries<IHasDate>();

        foreach (var entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTimeOffset.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedAt = DateTimeOffset.UtcNow;
                    break;
            }
        }
    }
}
