namespace Flow.Domain.Accounts;

public interface IAccountRepository : IRepository<Account>
{
    Task<Account?> GetForUserAsync(Guid userId, Guid accountId, CancellationToken cancellationToken = default);
}