using Flow.Domain.Income;

namespace Flow.Infrastructure.Persistence.Repositories;

internal sealed class UserIncomeRepository(FlowContext context)
    : BaseRepository<UserIncome, UserIncomeId>(context), IUserIncomeRepository;