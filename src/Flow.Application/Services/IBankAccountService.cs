using Flow.Application.Models.BankAccount;

namespace Flow.Application.Services;

public interface IBankAccountService
{
    Task<BankAccountDto> GetAsync(Guid userId, Guid accountId, CancellationToken cancellationToken = default);

    Task<List<BankAccountDto>> GetAllAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<BankAccountDto> CreateAsync(Guid userId, CreateBankAccountDto createDto, CancellationToken cancellationToken = default);

    Task UpdateAsync(Guid userId, Guid accountId, UpdateBankAccountDto updateBankAccountDto, CancellationToken cancellationToken = default);

    Task ArchiveAsync(Guid userId, Guid accoutId, CancellationToken cancellationToken = default);
}
