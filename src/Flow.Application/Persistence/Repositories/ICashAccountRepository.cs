namespace Flow.Application.Persistence.Repositories;

public interface ICashAccountRepository : IRepository<CashAccount>
{
    Task<CashAccount?> GetForUserAsync(Guid userId, Guid cashAccountId, CancellationToken cancellationToken = default);

    Task<List<CashAccount>> GetAllForUserAsync(Guid userId, CancellationToken cancellationToken = default);
}