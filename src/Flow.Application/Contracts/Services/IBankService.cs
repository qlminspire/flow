using Flow.Application.Models.Bank;

namespace Flow.Application.Contracts.Services;

public interface IBankService
{
    Task<BankDto> GetAsync(Guid id, CancellationToken cancellationToken = default);

    Task<List<BankDto>> GetAsync(CancellationToken cancellationToken = default);

    Task<BankDto> CreateAsync(CreateBankDto dto, CancellationToken cancellationToken = default);

    Task UpdateAsync(Guid id, UpdateBankDto dto, CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(string name, CancellationToken cancellationToken = default);
}
