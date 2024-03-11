using Flow.Domain.Users;

namespace Flow.Application.Services;

public interface IAuthService
{
    Task<Token> AuthenticateAsync(string refreshToken, CancellationToken cancellationToken = default);

    Task<Token> AuthenticateAsync(string email, string password, CancellationToken cancellationToken = default);
}