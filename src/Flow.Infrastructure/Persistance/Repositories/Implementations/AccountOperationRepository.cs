using Flow.Application.Persistance.Repositories;
using Flow.Domain.Entities;

namespace Flow.Infrastructure.Persistance.Repositories.Implementations;

internal sealed class AccountOperationRepository : BaseRepository<AccountOperation>, IAccountOperationRepository
{
    public AccountOperationRepository(FlowContext context) : base(context)
    {
    }
}