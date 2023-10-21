using Flow.Application.Models.BankDeposit;

namespace Flow.Application.Services;

public interface IBankDepositService
{
    Task<BankDepositDto> GetAsync(Guid userId, Guid bankDepositId, CancellationToken cancellationToken = default);

    Task<List<BankDepositDto>> GetAllAsync(Guid userId, CancellationToken cancellationToken);

    Task<BankDepositDto> CreateAsync(Guid userId, CreateBankDepositDto createBankDepositDto, CancellationToken cancellationToken = default);
}
