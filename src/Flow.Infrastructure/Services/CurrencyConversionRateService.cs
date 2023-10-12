namespace Flow.Infrastructure.Services;

internal sealed class CurrencyConversionRateService : ICurrencyConversionRateService
{
    private readonly Dictionary<string, decimal> _conversionRates = new()
    {
        { "EUR/USD", 1.0831M },
        { "BYN/USD", 0.4M }
    };

    public decimal GetConversionRate(string sourceCurrency, string destinationCurrency)
    {
        if (sourceCurrency == destinationCurrency)
            return 1.0M;

        if (_conversionRates.TryGetValue($"{sourceCurrency}/{destinationCurrency}", out var rate))
            return rate;

        if (_conversionRates.TryGetValue($"{destinationCurrency}/{sourceCurrency}", out rate))
            return 1 / rate;

        return 1.0M;
    }
}
