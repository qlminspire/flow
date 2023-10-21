using Flow.Application.Models.CashAccount;

namespace Flow.Application.Services;

public interface ICashAccountService
{
    Task<CashAccountDto> GetAsync(Guid userId, Guid cashAccountId, CancellationToken cancellationToken = default);

    Task<List<CashAccountDto>> GetAllAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<CashAccountDto> CreateAsync(Guid userId, CreateCashAccountDto createCashAccountDto, CancellationToken cancellationToken = default);
}
