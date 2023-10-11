﻿using Flow.Application.Contracts.Persistence.Repositories;

namespace Flow.Infrastructure.Persistence.Repositories.Implementations;

internal sealed class BankDepositRepository : BaseRepository<BankDeposit>, IBankDepositRepository
{
    public BankDepositRepository(FlowContext context) : base(context)
    {
    }
}
