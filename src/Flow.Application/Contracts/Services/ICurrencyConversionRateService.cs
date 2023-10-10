namespace Flow.Application.Contracts.Services;

public interface ICurrencyConversionRateService
{
    decimal GetConversionRate(string sourceCurrency, string destinationCurrency);
}
