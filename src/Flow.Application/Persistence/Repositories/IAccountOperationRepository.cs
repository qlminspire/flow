namespace Flow.Application.Persistence.Repositories;

public interface IAccountOperationRepository : IRepository<AccountOperation>
{
    Task<AccountOperation?> GetForUserAsync(Guid userId, Guid operationId,
        CancellationToken cancellationToken = default);

    Task<List<AccountOperation>> GetAllIncomingOperationsAsync(Guid accountId, CancellationToken cancellationToken = default);

    Task<List<AccountOperation>> GetAllOutgoingOperationsAsync(Guid accountId, CancellationToken cancellationToken = default);
}
