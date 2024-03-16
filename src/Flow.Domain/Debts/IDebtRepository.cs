using Flow.Domain.Users;

namespace Flow.Domain.Debts;

public interface IDebtRepository : IRepository<Debt, DebtId>
{
    Task<Debt?> GetForUserAsync(UserId userId, DebtId debtId, CancellationToken cancellationToken = default);

    Task<List<Debt>> GetAllForUserAsync(UserId userId, CancellationToken cancellationToken = default);
}