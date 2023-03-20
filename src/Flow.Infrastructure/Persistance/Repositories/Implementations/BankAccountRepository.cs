using Flow.Application.Persistance.Repositories;
using Flow.Domain.Entities;

namespace Flow.Infrastructure.Persistance.Repositories.Implementations;

internal sealed class BankAccountRepository : BaseRepository<BankAccount>, IBankAccountRepository
{
    public BankAccountRepository(FlowContext context) : base(context)
    {
    }
}
