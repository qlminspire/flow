using Flow.Application.Contracts.Persistence.Repositories;

namespace Flow.Infrastructure.Persistence.Repositories.Implementations;

internal sealed class AccountRepository : BaseRepository<Account>, IAccountRepository
{
    public AccountRepository(FlowContext context) : base(context)
    {
    }
}
