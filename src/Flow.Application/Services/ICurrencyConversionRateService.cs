using Flow.Domain.Currencies;

namespace Flow.Application.Services;

public interface ICurrencyConversionRateService
{
    decimal GetConversionRate(CurrencyCode sourceCurrencyCode, CurrencyCode targetCurrencyCode);
}