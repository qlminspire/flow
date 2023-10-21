namespace Flow.Application.Persistence.Repositories;

public interface IBankDepositRepository : IRepository<BankDeposit>
{
    Task<BankDeposit?> GetForUserAsync(Guid userId, Guid bankDepositId, CancellationToken cancellationToken);

    Task<List<BankDeposit>> GetAllForUserAsync(Guid userId, CancellationToken cancellationToken);
}
