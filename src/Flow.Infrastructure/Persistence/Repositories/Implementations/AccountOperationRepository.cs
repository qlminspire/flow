using Flow.Application.Contracts.Persistence.Repositories;

namespace Flow.Infrastructure.Persistence.Repositories.Implementations;

internal sealed class AccountOperationRepository : BaseRepository<AccountOperation>, IAccountOperationRepository
{
    public AccountOperationRepository(FlowContext context) : base(context)
    {
    }
}