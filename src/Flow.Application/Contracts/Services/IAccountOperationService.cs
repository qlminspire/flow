using Flow.Application.Models.AccountOperation;

namespace Flow.Application.Contracts.Services;

public interface IAccountOperationService
{
    Task<AccountOperationDto> GetAsync(Guid userId, Guid operationId, CancellationToken cancellationToken = default);

    Task<AccountOperationDto> CreateAsync(Guid userId, CreateAccountOperationDto createAccountOperationDto, CancellationToken cancellationToken = default);
}
