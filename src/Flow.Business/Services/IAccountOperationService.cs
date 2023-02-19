using Flow.Api.Models.AccountOperation;
using Flow.Business.Models.AccountOperation;

namespace Flow.Business.Services;

public interface IAccountOperationService
{
    Task<AccountOperationDto> CreateAsync(Guid userId, CreateAccountOperationDto createAccountOperationDto, CancellationToken cancellationToken);
}
