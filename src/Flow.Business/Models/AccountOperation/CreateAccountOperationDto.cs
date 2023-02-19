using Flow.Entities.Core.Enums;

namespace Flow.Business.Models.AccountOperation;

public sealed record CreateAccountOperationDto(AccountOperationType type, Guid accountId, decimal Price);