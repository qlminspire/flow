using Flow.Domain.Entities.Auth;

namespace Flow.Application.Contracts.Persistence.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
}