using Flow.Domain.Currencies;

namespace Flow.Infrastructure.Persistence.Repositories;

internal sealed class CurrencyRepository(FlowContext context)
    : BaseRepository<Currency>(context), ICurrencyRepository
{
    public Task<Currency?> GetByCurrencyCodeAsync(CurrencyCode currencyCode,
        CancellationToken cancellationToken = default)
    {
        return All.FirstOrDefaultAsync(x => x.Code == currencyCode, cancellationToken);
    }
}