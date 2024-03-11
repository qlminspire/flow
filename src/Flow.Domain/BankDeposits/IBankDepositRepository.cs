namespace Flow.Domain.BankDeposits;

public interface IBankDepositRepository : IRepository<BankDeposit>
{
    Task<BankDeposit?> GetForUserAsync(Guid userId, Guid bankDepositId, CancellationToken cancellationToken = default);

    Task<List<BankDeposit>> GetAllForUserAsync(Guid userId, CancellationToken cancellationToken = default);
}