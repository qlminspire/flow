using Flow.Application.Contracts.Persistence.Repositories;

namespace Flow.Infrastructure.Persistence.Repositories.Implementations;

internal sealed class BankAccountRepository : BaseRepository<BankAccount>, IBankAccountRepository
{
    public BankAccountRepository(FlowContext context) : base(context)
    {
    }
}
