namespace Flow.Application.Models.UserCategory;

public sealed record CreateUserCategoryDto
{
    public string Name { get; init; }

    public string? Description { get; init; }
}
