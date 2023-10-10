using Flow.Application.Contracts.Persistence.Repositories;
using Flow.Domain.Entities;

namespace Flow.Infrastructure.Persistence.Repositories.Implementations;

internal sealed class AccountOperationRepository : BaseRepository<AccountOperation>, IAccountOperationRepository
{
    public AccountOperationRepository(FlowContext context) : base(context)
    {
    }
}