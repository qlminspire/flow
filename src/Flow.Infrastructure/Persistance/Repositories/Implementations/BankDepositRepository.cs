using Flow.Application.Persistance.Repositories;
using Flow.Domain.Entities;

namespace Flow.Infrastructure.Persistance.Repositories.Implementations;

internal sealed class BankDepositRepository : BaseRepository<BankDeposit>, IBankDepositRepository
{
    public BankDepositRepository(FlowContext context) : base(context)
    {
    }
}
