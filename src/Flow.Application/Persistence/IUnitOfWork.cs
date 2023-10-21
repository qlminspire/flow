using Flow.Application.Persistence.Repositories;

namespace Flow.Application.Persistence;

public interface IUnitOfWork
{
    IUserRepository Users { get; }

    IUserCategoryRepository UserCategories { get; }

    IUserIncomeRepository UserIncomes { get; }

    ISubscriptionRepository Subscriptions { get; }

    IBankRepository Banks { get; }

    ICurrencyRepository Currencies { get; }

    IAccountRepository Accounts { get; }

    IBankAccountRepository BankAccounts { get; }

    ICashAccountRepository CashAccounts { get; }

    IBankDepositRepository BankDeposits { get; }

    IAccountOperationRepository AccountOperations { get; }

    IPlannedExpenseRepository PlannedExpenses { get; }

    IUserPreferencesRepository UserPreferences { get; }

    IDebtRepository Debts { get; }

    Task<bool> CanConnectAsync(CancellationToken cancellationToken = default);

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
