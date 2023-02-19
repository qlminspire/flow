using Flow.DataAccess.Contracts.Repositories;
using Flow.Entities;

namespace Flow.DataAccess.Repositories.Implementations;

internal sealed class BankRepository : BaseRepository<Bank>, IBankRepository
{
    public BankRepository(FlowContext context) : base(context)
    {
    }
}
