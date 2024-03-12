namespace Flow.Infrastructure.Services;

internal sealed class CurrencyConversionRateService : ICurrencyConversionRateService
{
    private readonly Dictionary<string, decimal> _conversionRates = new()
    {
        { "EUR/USD", 1.0831M },
        { "BYN/USD", 0.32M }
    };

    public decimal GetConversionRate(string sourceCurrency, string targetCurrency)
    {
        if (sourceCurrency == targetCurrency)
            return 1.0M;

        if (_conversionRates.TryGetValue($"{sourceCurrency}/{targetCurrency}", out var rate))
            return rate;

        if (_conversionRates.TryGetValue($"{targetCurrency}/{sourceCurrency}", out rate))
            return 1 / rate;

        throw new ArgumentException("The are no path for selected currencies");
    }
}