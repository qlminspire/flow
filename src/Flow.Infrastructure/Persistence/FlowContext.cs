using System.Reflection;
using Flow.Domain.AccountOperations;
using Flow.Domain.Accounts;
using Flow.Domain.BankDeposits;
using Flow.Domain.Banks;
using Flow.Domain.Currencies;
using Flow.Domain.Debts;
using Flow.Domain.Income;
using Flow.Domain.PlannedExpenses;
using Flow.Domain.Subscriptions;
using Flow.Domain.UserCategories;
using Flow.Domain.UserPreferences;
using Flow.Domain.Users;

namespace Flow.Infrastructure.Persistence;

public class FlowContext : DbContext
{
    public FlowContext(DbContextOptions<FlowContext> options)
        : base(options)
    {
    }

    public DbSet<Bank> Banks => Set<Bank>();

    public DbSet<Currency> Currencies => Set<Currency>();

    public DbSet<Account> Accounts => Set<Account>();

    public DbSet<AccountOperation> AccountOperations => Set<AccountOperation>();

    public DbSet<BankAccount> BankAccounts => Set<BankAccount>();

    public DbSet<BankDeposit> BankDeposits => Set<BankDeposit>();

    public DbSet<CashAccount> CashAccounts => Set<CashAccount>();

    public DbSet<Subscription> Subscriptions => Set<Subscription>();

    public DbSet<User> Users => Set<User>();

    public DbSet<UserCategory> UserCategories => Set<UserCategory>();

    public DbSet<UserIncome> UserIncomes => Set<UserIncome>();

    public DbSet<PlannedExpense> PlannedExpenses => Set<PlannedExpense>();

    public DbSet<UserPreferences> UserPreferences => Set<UserPreferences>();

    public DbSet<Debt> Debts => Set<Debt>();

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
        var entries = ChangeTracker.Entries<IAuditable>();

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