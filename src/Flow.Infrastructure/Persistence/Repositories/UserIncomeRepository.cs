namespace Flow.Infrastructure.Persistence.Repositories;

internal sealed class UserIncomeRepository : BaseRepository<UserIncome>, IUserIncomeRepository
{
    public UserIncomeRepository(FlowContext context) : base(context)
    {
    }
}
