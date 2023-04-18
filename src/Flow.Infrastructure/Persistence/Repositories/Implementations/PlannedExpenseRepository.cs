using Flow.Application.Persistence.Repositories;
using Flow.Domain.Entities;

namespace Flow.Infrastructure.Persistence.Repositories.Implementations;

internal sealed class PlannedExpenseRepository: BaseRepository<PlannedExpense>, IPlannedExpenseRepository
{
    public PlannedExpenseRepository(FlowContext context) : base(context)
    {
    }
}
