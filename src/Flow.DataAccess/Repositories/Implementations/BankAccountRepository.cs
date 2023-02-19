using Flow.Entities;
using Flow.DataAccess.Contracts.Repositories;

namespace Flow.DataAccess.Repositories.Implementations;

internal sealed class BankAccountRepository : BaseRepository<BankAccount>, IBankAccountRepository
{
    public BankAccountRepository(FlowContext context) : base(context)
    {
    }
}
