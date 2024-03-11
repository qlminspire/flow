using Flow.Domain.Currencies;

namespace Flow.Infrastructure.Persistence.Repositories;

internal sealed class CurrencyRepository(FlowContext context)
    : BaseRepository<Currency>(context), ICurrencyRepository;