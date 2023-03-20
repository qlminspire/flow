using Flow.Application.Persistance.Repositories;
using Flow.Domain.Entities;

namespace Flow.Infrastructure.Persistance.Repositories.Implementations;

internal sealed class CashAccountRepository : BaseRepository<CashAccount>, ICashAccountRepository
{
    public CashAccountRepository(FlowContext context) : base(context)
    {
    }
}
