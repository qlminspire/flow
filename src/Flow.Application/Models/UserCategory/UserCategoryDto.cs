namespace Flow.Application.Models.UserCategory;

public sealed record UserCategoryDto
{
    public Guid Id { get; init; }

    public string Name { get; init; }

    public string? Description { get; init; }
}
