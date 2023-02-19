using Flow.DataAccess.Contracts.Repositories;
using Flow.Entities;

namespace Flow.DataAccess.Repositories.Implementations;

internal sealed class AccountOperationRepository : BaseRepository<AccountOperation>, IAccountOperationRepository
{
    public AccountOperationRepository(FlowContext context) : base(context)
    {
    }
}