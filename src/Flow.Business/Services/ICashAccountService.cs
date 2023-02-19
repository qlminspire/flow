using Flow.Business.Models.CashAccount;

namespace Flow.Business.Services;

public interface ICashAccountService
{
    Task<CashAccountDto> GetAsync(Guid userId, Guid accountId, CancellationToken cancellationToken = default);

    Task<List<CashAccountDto>> GetAllAsync(Guid userId,  CancellationToken cancellationToken = default);

    Task<CashAccountDto> CreateAsync(Guid userId, CreateCashAccountDto createDto, CancellationToken cancellationToken = default);

    Task UpdateAsync(Guid userId, Guid accountId, UpdateCashAccountDto updateCashAccountDto, CancellationToken cancellationToken = default);

    Task ArchiveAsync(Guid userId, Guid accoutId,  CancellationToken cancellationToken = default);
}
