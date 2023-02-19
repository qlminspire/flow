using Flow.DataAccess.Contracts.Repositories;
using Flow.Entities;

namespace Flow.DataAccess.Repositories.Implementations;

internal sealed class CashAccountRepository : BaseRepository<CashAccount>, ICashAccountRepository
{
    public CashAccountRepository(FlowContext context) : base(context)
    {
    }
}
