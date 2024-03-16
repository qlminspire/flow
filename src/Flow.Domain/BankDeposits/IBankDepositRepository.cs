using Flow.Domain.Banks;
using Flow.Domain.Users;

namespace Flow.Domain.BankDeposits;

public interface IBankDepositRepository : IRepository<BankDeposit, BankDepositId>
{
    Task<BankDeposit?> GetForUserAsync(UserId userId, BankDepositId bankDepositId,
        CancellationToken cancellationToken = default);

    Task<List<BankDeposit>> GetAllForUserAsync(UserId userId, CancellationToken cancellationToken = default);
}