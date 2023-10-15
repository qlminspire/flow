using Flow.Application.Models.Debt;

namespace Flow.Application.Contracts.Services;

public interface IDebtService
{
    Task<DebtDto> GetAsync(Guid userId, Guid debtId, CancellationToken cancellationToken = default);

    Task<List<DebtDto>> GetAllAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<DebtDto> CreateAsync(Guid userId, CreateDebtDto createDebtDto, CancellationToken cancellationToken = default);
}
