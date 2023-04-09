using Flow.Application.Persistence.Repositories;
using Flow.Domain.Entities;
using Flow.Infrastructure.Persistence;
using Flow.Infrastructure.Persistence.Repositories;

namespace Flow.Infrastructure.Persistence.Repositories.Implementations;

internal sealed class BankAccountRepository : BaseRepository<BankAccount>, IBankAccountRepository
{
    public BankAccountRepository(FlowContext context) : base(context)
    {
    }
}
