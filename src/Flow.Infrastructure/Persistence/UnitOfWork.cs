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

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly FlowContext _context;

    private IAccountOperationRepository? _accountOperationRepository;

    private IAccountRepository? _accountRepository;
    private IBankAccountRepository? _bankAccountRepository;

    private IBankDepositRepository? _bankDepositRepository;

    private IBankRepository? _bankRepository;
    private ICashAccountRepository? _cashAccountRepository;
    private ICurrencyRepository? _currencyRepository;
    private IDebtRepository? _debtRepository;

    private IPlannedExpenseRepository? _plannedExpenseRepository;

    private ISubscriptionRepository? _subscriptionRepository;
    private IUserCategoryRepository? _userCategoryRepository;
    private IUserIncomeRepository? _userIncomeRepository;

    private IUserPreferencesRepository? _userPreferencesRepository;

    private IUserRepository? _userRepository;

    public UnitOfWork(FlowContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IUserRepository Users => _userRepository ??= new UserRepository(_context);

    public IBankRepository Banks => _bankRepository ??= new BankRepository(_context);

    public IAccountRepository Accounts => _accountRepository ??= new AccountRepository(_context);

    public IBankAccountRepository BankAccounts => _bankAccountRepository ??= new BankAccountRepository(_context);

    public ICurrencyRepository Currencies => _currencyRepository ??= new CurrencyRepository(_context);

    public ICashAccountRepository CashAccounts => _cashAccountRepository ??= new CashAccountRepository(_context);

    public ISubscriptionRepository Subscriptions => _subscriptionRepository ??= new SubscriptionRepository(_context);

    public IUserCategoryRepository UserCategories => _userCategoryRepository ??= new UserCategoryRepository(_context);

    public IUserIncomeRepository UserIncomes => _userIncomeRepository ??= new UserIncomeRepository(_context);

    public IBankDepositRepository BankDeposits => _bankDepositRepository ??= new BankDepositRepository(_context);

    public IAccountOperationRepository AccountOperations =>
        _accountOperationRepository ??= new AccountOperationRepository(_context);

    public IPlannedExpenseRepository PlannedExpenses =>
        _plannedExpenseRepository ??= new PlannedExpenseRepository(_context);

    public IUserPreferencesRepository UserPreferences =>
        _userPreferencesRepository ??= new UserPreferencesRepository(_context);

    public IDebtRepository Debts => _debtRepository ??= new DebtRepository(_context);

    public Task<bool> CanConnectAsync(CancellationToken cancellationToken = default)
    {
        return _context.Database.CanConnectAsync(cancellationToken);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}