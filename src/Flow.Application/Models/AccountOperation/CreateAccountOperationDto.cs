using Flow.Domain.Enums;

namespace Flow.Application.Models.AccountOperation;

public sealed record CreateAccountOperationDto(AccountOperationType type, Guid accountId, decimal Price);