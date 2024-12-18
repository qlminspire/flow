﻿namespace Flow.Application.Models.AccountOperation;

public sealed class AccountOperationDto
{
    public Guid Id { get; init; }

    public Guid FromAccountId { get; init; }

    public Guid ToAccountId { get; init; }

    public decimal Amount { get; init; }
}
