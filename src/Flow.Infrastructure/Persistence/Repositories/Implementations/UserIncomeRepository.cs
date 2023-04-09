using Flow.Application.Persistence.Repositories;
using Flow.Domain.Entities;

namespace Flow.Infrastructure.Persistence.Repositories.Implementations;

internal sealed class UserIncomeRepository : BaseRepository<UserIncome>, IUserIncomeRepository
{
    public UserIncomeRepository(FlowContext context) : base(context)
    {
    }
}
