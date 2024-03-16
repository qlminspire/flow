namespace Flow.Domain.Currencies;

public interface ICurrencyRepository : IRepository<Currency, CurrencyId>
{
    Task<Currency?> GetByCurrencyCodeAsync(CurrencyCode currencyCode, CancellationToken cancellationToken = default);
}