using Flow.DataAccess.Contracts.Repositories;

namespace Flow.DataAccess.Contracts;

public interface IUnitOfWork
{
    IUserRepository Users { get; }

    IUserCategoryRepository UserCategories { get; }

    IUserIncomeRepository UserIncomes { get; }

    ISubscriptionRepository Subscriptions { get; }

    IBankRepository Banks { get; }

    ICurrencyRepository Currencies { get; }

    IBankAccountRepository BankAccounts { get; }

    ICashAccountRepository CashAccounts { get; }

    IBankDepositRepository BankDeposits { get; }

    IAccountOperationRepository AccountOperations { get; }

    Task<bool> CanConnectAsync(CancellationToken cancellationToken = default);

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
