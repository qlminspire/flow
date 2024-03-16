using Flow.Domain.Users;

namespace Flow.Domain.Accounts;

public interface IBankAccountRepository : IRepository<BankAccount, AccountId>
{
    Task<BankAccount?> GetForUserAsync(UserId userId, AccountId bankAccountId,
        CancellationToken cancellationToken = default);

    Task<List<BankAccount>> GetAllForUserAsync(UserId userId, CancellationToken cancellationToken = default);
}