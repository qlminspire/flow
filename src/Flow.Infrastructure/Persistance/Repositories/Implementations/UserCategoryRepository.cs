using Flow.Application.Persistance.Repositories;
using Flow.Domain.Entities;
using Flow.Infrastructure.Persistance;

namespace Flow.Infrastructure.Persistance.Repositories.Implementations;

internal sealed class UserCategoryRepository : BaseRepository<UserCategory>, IUserCategoryRepository
{
    public UserCategoryRepository(FlowContext context) : base(context)
    {
    }
}
