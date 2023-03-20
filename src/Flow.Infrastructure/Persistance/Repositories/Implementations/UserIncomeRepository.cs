using Flow.Application.Persistance.Repositories;
using Flow.Domain.Entities;

namespace Flow.Infrastructure.Persistance.Repositories.Implementations;

internal sealed class UserIncomeRepository : BaseRepository<UserIncome>, IUserIncomeRepository
{
    public UserIncomeRepository(FlowContext context) : base(context)
    {
    }
}
