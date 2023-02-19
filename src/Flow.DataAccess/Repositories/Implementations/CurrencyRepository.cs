using Flow.Entities;
using Flow.DataAccess.Contracts.Repositories;

namespace Flow.DataAccess.Repositories.Implementations;

internal sealed class CurrencyRepository : BaseRepository<Currency>, ICurrencyRepository
{
    public CurrencyRepository(FlowContext context) : base(context)
    {
    }
}
