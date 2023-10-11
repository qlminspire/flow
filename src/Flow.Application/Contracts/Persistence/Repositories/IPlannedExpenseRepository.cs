﻿using Flow.Application.Models.PlannedExpense;

namespace Flow.Application.Contracts.Persistence.Repositories;

public interface IPlannedExpenseRepository : IRepository<PlannedExpense>
{
    Task<List<MonthlyPlannedExpenseDto>> GetAggregatedByCurrencyAsync(Guid userId, DateOnly startDate, CancellationToken cancellationToken);
}
