using Flow.Application.Contracts.Persistence.Repositories;

namespace Flow.Infrastructure.Persistence.Repositories.Implementations;

internal sealed class CurrencyRepository : BaseRepository<Currency>, ICurrencyRepository
{
    public CurrencyRepository(FlowContext context) : base(context)
    {
    }
}
