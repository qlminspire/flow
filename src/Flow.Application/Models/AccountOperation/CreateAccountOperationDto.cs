namespace Flow.Application.Models.AccountOperation;

public sealed record CreateAccountOperationDto(Guid FromAccountId, Guid ToAccountId, decimal Amount);