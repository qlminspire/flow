using Flow.Domain.Users;

namespace Flow.Domain.UserCategories;

public sealed class UserCategory : Entity, IAuditable
{
    private UserCategory(
        Guid id,
        User user,
        UserCategoryName name,
        DateTime createdAt
    )
        : base(id)
    {
        UserId = user.Id;
        Name = name;
        CreatedAt = createdAt;
    }

    private UserCategory()
    {
    }

    public UserCategoryName Name { get; private set; }

    public Guid UserId { get; private set; }

    public User? User { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public static Result<UserCategory> Create(User user, UserCategoryName name, DateTime createdAt)
    {
        return new UserCategory(Guid.NewGuid(), user, name, createdAt);
    }
}