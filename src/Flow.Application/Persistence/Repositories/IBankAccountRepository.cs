namespace Flow.Application.Persistence.Repositories;

public interface IBankAccountRepository : IRepository<BankAccount>
{
    Task<BankAccount?> GetForUserAsync(Guid userId, Guid bankAccountId, CancellationToken cancellationToken);

    Task<List<BankAccount>> GetAllForUserAsync(Guid userId, CancellationToken cancellationToken);
}
