using Flow.Application.Contracts.Persistence.Repositories;

namespace Flow.Infrastructure.Persistence.Repositories.Implementations;
internal sealed class DebtRepository : BaseRepository<Debt>, IDebtRepository
{
    public DebtRepository(FlowContext context) : base(context)
    {
    }
}
