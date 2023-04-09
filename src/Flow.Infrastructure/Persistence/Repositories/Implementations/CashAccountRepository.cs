using Flow.Application.Persistence.Repositories;
using Flow.Domain.Entities;

namespace Flow.Infrastructure.Persistence.Repositories.Implementations;

internal sealed class CashAccountRepository : BaseRepository<CashAccount>, ICashAccountRepository
{
    public CashAccountRepository(FlowContext context) : base(context)
    {
    }
}
