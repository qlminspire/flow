using Flow.DataAccess.Contracts;
using Flow.DataAccess.Contracts.Repositories;
using Flow.DataAccess.Repositories.Implementations;

namespace Flow.DataAccess.Repositories;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly FlowContext _context;

    private IUserRepository? _userRepository;
    private IUserCategoryRepository? _userCategoryRepository;
    private IUserIncomeRepository? _userIncomeRepository;

    private IBankRepository? _bankRepository;
    private ICurrencyRepository? _currencyRepository;

    private IBankAccountRepository? _bankAccountRepository;
    private ICashAccountRepository? _cashAccountRepository;
    private IAccountOperationRepository? _accountOperationRepository;

    private ISubscriptionRepository? _subscriptionRepository;

    private IBankDepositRepository? _bankDepositRepository;

    public UnitOfWork(FlowContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IUserRepository Users => _userRepository ??= new UserRepository(_context);

    public IBankRepository Banks => _bankRepository ??= new BankRepository(_context);

    public IBankAccountRepository BankAccounts => _bankAccountRepository ??= new BankAccountRepository(_context);

    public ICurrencyRepository Currencies => _currencyRepository ??= new CurrencyRepository(_context);

    public ICashAccountRepository CashAccounts => _cashAccountRepository ??= new CashAccountRepository(_context);

    public ISubscriptionRepository Subscriptions => _subscriptionRepository ??= new SubscriptionRepository(_context);

    public IUserCategoryRepository UserCategories => _userCategoryRepository ??= new UserCategoryRepository(_context);

    public IUserIncomeRepository UserIncomes => _userIncomeRepository ??= new UserIncomeRepository(_context);

    public IBankDepositRepository BankDeposits => _bankDepositRepository ??= new BankDepositRepository(_context);

    public IAccountOperationRepository AccountOperations => _accountOperationRepository ??= new AccountOperationRepository(_context);

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}
