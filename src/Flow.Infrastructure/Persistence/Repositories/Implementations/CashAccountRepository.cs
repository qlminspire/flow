using Flow.Application.Contracts.Persistence.Repositories;

namespace Flow.Infrastructure.Persistence.Repositories.Implementations;

internal sealed class CashAccountRepository : BaseRepository<CashAccount>, ICashAccountRepository
{
    public CashAccountRepository(FlowContext context) : base(context)
    {
    }
}
