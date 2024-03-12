﻿namespace Flow.Domain.Debts;

public interface IDebtRepository : IRepository<Debt>
{
    Task<Debt?> GetForUserAsync(Guid userId, Guid debtId, CancellationToken cancellationToken = default);

    Task<List<Debt>> GetAllForUserAsync(Guid userId, CancellationToken cancellationToken = default);
}