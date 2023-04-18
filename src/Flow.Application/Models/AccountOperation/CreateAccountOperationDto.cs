using Flow.Domain.Enums;

namespace Flow.Application.Models.AccountOperation;

public sealed record CreateAccountOperationDto(AccountOperationType Type, Guid AccountId, decimal Price);