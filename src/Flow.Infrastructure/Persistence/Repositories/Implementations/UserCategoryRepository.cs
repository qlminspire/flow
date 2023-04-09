using Flow.Application.Persistence.Repositories;
using Flow.Domain.Entities;
using Flow.Infrastructure.Persistence;
using Flow.Infrastructure.Persistence.Repositories;

namespace Flow.Infrastructure.Persistence.Repositories.Implementations;

internal sealed class UserCategoryRepository : BaseRepository<UserCategory>, IUserCategoryRepository
{
    public UserCategoryRepository(FlowContext context) : base(context)
    {
    }
}
