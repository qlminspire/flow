using Flow.Application.Persistance.Repositories;
using Flow.Domain.Entities;
using Flow.Infrastructure.Persistance;

namespace Flow.Infrastructure.Persistance.Repositories.Implementations;

internal sealed class CurrencyRepository : BaseRepository<Currency>, ICurrencyRepository
{
    public CurrencyRepository(FlowContext context) : base(context)
    {
    }
}
