using Flow.DataAccess.Contracts.Repositories;
using Flow.Entities;

namespace Flow.DataAccess.Repositories.Implementations;

internal sealed class UserIncomeRepository : BaseRepository<UserIncome>, IUserIncomeRepository
{
    public UserIncomeRepository(FlowContext context) : base(context)
    {
    }
}
