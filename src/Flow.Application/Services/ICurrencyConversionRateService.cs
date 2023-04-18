namespace Flow.Application.Services;

public interface ICurrencyConversionRateService
{
    decimal GetConversionRate(string sourceCurrency, string destinationCurrency);
}
