using Flow.Application.Contracts.Persistence.Repositories;

namespace Flow.Infrastructure.Persistence.Repositories.Implementations;

internal sealed class UserIncomeRepository : BaseRepository<UserIncome>, IUserIncomeRepository
{
    public UserIncomeRepository(FlowContext context) : base(context)
    {
    }
}
