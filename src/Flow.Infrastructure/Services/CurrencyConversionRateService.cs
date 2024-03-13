using Flow.Domain.Currencies;

namespace Flow.Infrastructure.Services;

internal sealed class CurrencyConversionRateService : ICurrencyConversionRateService
{
    private readonly Dictionary<string, decimal> _conversionRates = new()
    {
        { "EUR/USD", 1.0831m },
        { "USD/BYN", 3.2m },
        { "EUR/BYN", 3.4m }
    };

    public decimal GetConversionRate(CurrencyCode sourceCurrencyCode, CurrencyCode targetCurrencyCode)
    {
        if (sourceCurrencyCode == targetCurrencyCode)
            return 1.0m;

        if (_conversionRates.TryGetValue($"{sourceCurrencyCode.Value}/{targetCurrencyCode.Value}", out var rate))
            return rate;

        if (_conversionRates.TryGetValue($"{targetCurrencyCode.Value}/{sourceCurrencyCode.Value}", out rate))
            return 1 / rate;

        throw new ArgumentException("The are no path for selected currencies");
    }
}