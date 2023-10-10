using Flow.Application.Models.BankDeposit;

namespace Flow.Application.Contracts.Services;

public interface IBankDepositService
{
    Task<BankDepositDto> GetAsync(Guid userId, Guid depositId, CancellationToken cancellationToken = default);

    Task<List<BankDepositDto>> GetAllAsync(Guid userId, CancellationToken cancellationToken);

    Task<BankDepositDto> CreateAsync(Guid userId, CreateBankDepositDto createBankDepositDto, CancellationToken cancellationToken = default);
}
