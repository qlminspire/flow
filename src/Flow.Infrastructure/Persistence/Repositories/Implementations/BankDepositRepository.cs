using Flow.Application.Persistence.Repositories;
using Flow.Domain.Entities;

namespace Flow.Infrastructure.Persistence.Repositories.Implementations;

internal sealed class BankDepositRepository : BaseRepository<BankDeposit>, IBankDepositRepository
{
    public BankDepositRepository(FlowContext context) : base(context)
    {
    }
}
