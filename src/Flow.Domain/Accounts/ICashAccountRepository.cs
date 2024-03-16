using Flow.Domain.Users;

namespace Flow.Domain.Accounts;

public interface ICashAccountRepository : IRepository<CashAccount, AccountId>
{
    Task<CashAccount?> GetForUserAsync(UserId userId, AccountId cashAccountId,
        CancellationToken cancellationToken = default);

    Task<List<CashAccount>> GetAllForUserAsync(UserId userId, CancellationToken cancellationToken = default);
}