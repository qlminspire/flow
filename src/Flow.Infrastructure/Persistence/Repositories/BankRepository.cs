using Flow.Domain.Banks;

namespace Flow.Infrastructure.Persistence.Repositories;

internal sealed class BankRepository(FlowContext context)
    : BaseRepository<Bank>(context), IBankRepository;