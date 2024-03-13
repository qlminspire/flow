namespace Flow.Domain.Currencies;

public interface ICurrencyRepository : IRepository<Currency>
{
    Task<Currency?> GetByCurrencyCodeAsync(CurrencyCode currencyCode, CancellationToken cancellationToken = default);
}