using Flow.DataAccess.Contracts.Repositories;
using Flow.Entities;

namespace Flow.DataAccess.Repositories.Implementations;

internal sealed class BankDepositRepository : BaseRepository<BankDeposit>, IBankDepositRepository
{
    public BankDepositRepository(FlowContext context) : base(context)
    {
    }
}
