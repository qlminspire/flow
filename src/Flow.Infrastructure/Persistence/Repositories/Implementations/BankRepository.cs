using Flow.Application.Persistence.Repositories;
using Flow.Domain.Entities;

namespace Flow.Infrastructure.Persistence.Repositories.Implementations;

internal sealed class BankRepository : BaseRepository<Bank>, IBankRepository
{
    public BankRepository(FlowContext context) : base(context)
    {
    }
}
