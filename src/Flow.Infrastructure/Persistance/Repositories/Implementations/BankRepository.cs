using Flow.Application.Persistance.Repositories;
using Flow.Domain.Entities;

namespace Flow.Infrastructure.Persistance.Repositories.Implementations;

internal sealed class BankRepository : BaseRepository<Bank>, IBankRepository
{
    public BankRepository(FlowContext context) : base(context)
    {
    }
}
