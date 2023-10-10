using Flow.Application.Contracts.Persistence.Repositories;
using Flow.Domain.Entities;

namespace Flow.Infrastructure.Persistence.Repositories.Implementations;

internal sealed class UserCategoryRepository : BaseRepository<UserCategory>, IUserCategoryRepository
{
    public UserCategoryRepository(FlowContext context) : base(context)
    {
    }
}
