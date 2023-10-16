namespace Flow.Application.Models.UserCategory;

public sealed record UpdateUserCategoryDto
{
    public string Name { get; init; }

    public string? Description { get; init; }
}
