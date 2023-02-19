using Flow.DataAccess.Contracts.Repositories;
using Flow.Entities;

namespace Flow.DataAccess.Repositories.Implementations;

internal sealed class UserCategoryRepository : BaseRepository<UserCategory>, IUserCategoryRepository
{
    public UserCategoryRepository(FlowContext context) : base(context)
    {
    }
}
