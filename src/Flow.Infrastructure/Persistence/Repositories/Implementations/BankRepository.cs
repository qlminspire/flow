using Flow.Application.Contracts.Persistence.Repositories;

namespace Flow.Infrastructure.Persistence.Repositories.Implementations;

internal sealed class BankRepository : BaseRepository<Bank>, IBankRepository
{
    public BankRepository(FlowContext context) : base(context)
    {
    }
}
