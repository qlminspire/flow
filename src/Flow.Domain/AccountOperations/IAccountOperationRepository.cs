using Flow.Domain.Accounts;
using Flow.Domain.Users;

namespace Flow.Domain.AccountOperations;

public interface IAccountOperationRepository : IRepository<AccountOperation, AccountOperationId>
{
    Task<AccountOperation?> GetForUserAsync(UserId userId, AccountOperationId operationId,
        CancellationToken cancellationToken = default);

    Task<List<AccountOperation>> GetAllIncomingOperationsAsync(AccountId accountId,
        CancellationToken cancellationToken = default);

    Task<List<AccountOperation>> GetAllOutgoingOperationsAsync(AccountId accountId,
        CancellationToken cancellationToken = default);
}