using Flow.Application.Models.AccountOperation;

namespace Flow.Application.Contracts.Services;

public interface IAccountOperationService
{
    Task<AccountOperationDto> CreateAsync(Guid userId, CreateAccountOperationDto createAccountOperationDto, CancellationToken cancellationToken);
}
