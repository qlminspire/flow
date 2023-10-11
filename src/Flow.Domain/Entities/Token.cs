namespace Flow.Domain.Entities;

public record Token(string AccessToken, string RefreshToken, string TokenType, string Resource)
{
    public DateTime IssuedAtUtc { get; init; }

    public DateTime JwtTokenExpiresAtUtc { get; init; }

    public DateTime RefreshTokenExpiresAtUtc { get; init; }
}