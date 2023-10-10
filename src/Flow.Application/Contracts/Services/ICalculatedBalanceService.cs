using Flow.Application.Models.Balance;

namespace Flow.Application.Contracts.Services;

public interface ICalculatedBalanceService
{
    Task<CalculatedBalanceDto> GetAsync(Guid userId, CancellationToken cancellationToken = default);
}
