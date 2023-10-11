using System.Reflection;

using Microsoft.EntityFrameworkCore;

using Flow.Domain.Common;

namespace Flow.Infrastructure.Persistence;

public class FlowContext : DbContext
{
    public FlowContext(DbContextOptions<FlowContext> options) : base(options)
    {
    }

    public DbSet<Account> Accounts { get; set; }

    public DbSet<AccountOperation> AccountOperations { get; set; }

    public DbSet<Bank> Banks { get; set; }

    public DbSet<BankAccount> BankAccounts { get; set; }

    public DbSet<BankDeposit> BankDeposits { get; set; }

    public DbSet<CashAccount> CashAccounts { get; set; }

    public DbSet<Currency> Currencies { get; set; }

    public DbSet<Subscription> Subscriptions { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<UserCategory> UserCategories { get; set; }

    public DbSet<UserIncome> UserIncomes { get; set; }

    public DbSet<PlannedExpense> PlannedExpenses { get; set; }

    public DbSet<UserPreferences> UserPreferences { get; set; }

    public DbSet<Debt> Debts { get; set; }

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
        var entries = ChangeTracker.Entries();

        foreach (var entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    ((IHasDate)entry.Entity).CreatedAt = DateTimeOffset.UtcNow;
                    break;
                case EntityState.Modified:
                    ((IHasDate)entry.Entity).UpdatedAt = DateTimeOffset.UtcNow;
                    break;
            }
        }
    }
}
