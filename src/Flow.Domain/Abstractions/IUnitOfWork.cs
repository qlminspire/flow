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

namespace Flow.Domain.Abstractions;

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