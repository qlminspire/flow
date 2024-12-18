﻿using Flow.Application.Contracts.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Flow.Infrastructure.Persistence.Repositories.Implementations;

internal sealed class BankAccountRepository : BaseRepository<BankAccount>, IBankAccountRepository
{
    public BankAccountRepository(FlowContext context) : base(context)
    {
    }

    public Task<BankAccount?> GetForUserAsync(Guid userId, Guid bankAccountId, CancellationToken cancellationToken)
    {
        return All
            .Include(x => x.Bank)
            .Include(x => x.Currency)
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.UserId == userId && x.Id == bankAccountId, cancellationToken);
    }

    public Task<List<BankAccount>> GetAllForUserAsync(Guid userId, CancellationToken cancellationToken)
    {
        return All.AsNoTrackingWithIdentityResolution()
            .Include(x => x.Bank)
            .Include(x => x.Currency)
            .Include(x => x.Category)
            .Where(x => x.UserId == userId)
            .ToListAsync(cancellationToken);
    }

}
