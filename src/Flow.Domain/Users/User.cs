using Flow.Domain.Users.Events;

namespace Flow.Domain.Users;

public sealed class User : AggregateRoot<UserId>, IAuditable
{
    private User(
        UserId id,
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

    public DateTime CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public static Result<User> Create(Email email, PasswordHash passwordHash, DateTime createdAt)
    {
        var user = new User(new UserId(Guid.NewGuid()), email, passwordHash, createdAt);

        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));

        return user;
    }

    public Result ChangeEmail(Email email, DateTime updatedAt)
    {
        Email = email;
        UpdatedAt = updatedAt;

        RaiseDomainEvent(new UserEmailChangedDomainEvent(Id));

        return Result.Success();
    }
}