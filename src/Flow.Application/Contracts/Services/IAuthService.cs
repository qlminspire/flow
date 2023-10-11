namespace Flow.Application.Contracts.Services;

public interface IAuthService
{
    Task<Token> AuthenticateAsync(string refreshToken, CancellationToken cancellationToken = default);

    Task<Token> AuthenticateAsync(string email, string password, CancellationToken cancellationToken = default);
}
