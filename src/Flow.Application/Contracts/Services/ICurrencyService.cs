using Flow.Application.Models.Currency;

namespace Flow.Application.Contracts.Services;

public interface ICurrencyService
{
    Task<CurrencyDto> GetAsync(Guid id, CancellationToken cancellationToken = default);

    Task<List<CurrencyDto>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<CurrencyDto> CreateAsync(CreateCurrencyDto createCurrencyDto, CancellationToken cancellationToken = default);

    Task UpdateAsync(Guid id, UpdateCurrencyDto updateCurrencyDto, CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(string code, CancellationToken cancellationToken = default);
}
