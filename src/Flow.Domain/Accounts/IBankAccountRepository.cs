namespace Flow.Domain.Accounts;

public interface IBankAccountRepository : IRepository<BankAccount>
{
    Task<BankAccount?> GetForUserAsync(Guid userId, Guid bankAccountId, CancellationToken cancellationToken = default);

    Task<List<BankAccount>> GetAllForUserAsync(Guid userId, CancellationToken cancellationToken = default);
}