using Flow.Domain.Users;

namespace Flow.Domain.Accounts;

public interface IAccountRepository : IRepository<Account, AccountId>
{
    Task<Account?> GetForUserAsync(UserId userId, AccountId accountId, CancellationToken cancellationToken = default);
}