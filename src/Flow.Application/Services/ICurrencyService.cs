using Flow.Application.Models.Currency;

using OneOf;
using OneOf.Types;

namespace Flow.Application.Services;

public interface ICurrencyService
{
    Task<OneOf<CurrencyDto, NotFound>> GetAsync(Guid id, CancellationToken cancellationToken = default);

    Task<List<CurrencyDto>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<CurrencyDto> CreateAsync(CreateCurrencyDto dto, CancellationToken cancellationToken = default);

    Task<OneOf<Success, NotFound>> UpdateAsync(Guid id, UpdateCurrencyDto dto, CancellationToken cancellationToken = default);

    Task<OneOf<Success, NotFound>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(string code, CancellationToken cancellationToken = default);
}
