using Flow.Domain.Users.Events;

namespace Flow.Domain.Users;

public sealed class User : AggregateRoot, IAuditable
{
    private User(
        Guid id,
        Email email,
        PasswordHash passwordHash,
        DateTime createdAt)
        : base(id)
    {
        Email = email;
        PasswordHash = passwordHash;
        CreatedAt = createdAt;
    }

    private User()
    {
    }

    public Email Email { get; private set; }

    public PasswordHash PasswordHash { get; private set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public static Result<User> Create(Email email, PasswordHash passwordHash, DateTime createdAt)
    {
        var user = new User(Guid.NewGuid(), email, passwordHash, createdAt);

        user.RaiseDomainEvent(new UserCreatedDomainEvent(new UserId(user.Id)));

        return user;
    }

    public Result ChangeEmail(Email email, DateTime updatedAt)
    {
        Email = email;
        UpdatedAt = updatedAt;

        RaiseDomainEvent(new UserEmailChangedDomainEvent(new UserId(Id)));

        return Result.Success();
    }
}