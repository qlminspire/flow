using Flow.Application.Models.AccountOperation;

namespace Flow.Application.Services;

public interface IAccountOperationService
{
    Task<AccountOperationDto> GetAsync(Guid userId, Guid accountOperationId, CancellationToken cancellationToken = default);

    Task<AccountOperationDto> CreateAsync(Guid userId, CreateAccountOperationDto createAccountOperationDto, CancellationToken cancellationToken = default);
}
