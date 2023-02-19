using Flow.Business.Models.Balance;

namespace Flow.Business.Services;

public interface ICalculatedBalanceService
{
    Task<CalculatedBalanceDto> GetAsync(Guid userId, CancellationToken cancellationToken = default);
}
