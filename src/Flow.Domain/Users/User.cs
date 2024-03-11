namespace Flow.Domain.Users;

public sealed class User : Entity, IAuditable
{
    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}