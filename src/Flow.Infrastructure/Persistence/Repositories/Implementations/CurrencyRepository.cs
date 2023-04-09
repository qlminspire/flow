using Flow.Application.Persistence.Repositories;
using Flow.Domain.Entities;
using Flow.Infrastructure.Persistence.Repositories;

namespace Flow.Infrastructure.Persistence.Repositories.Implementations;

internal sealed class CurrencyRepository : BaseRepository<Currency>, ICurrencyRepository
{
    public CurrencyRepository(FlowContext context) : base(context)
    {
    }
}
