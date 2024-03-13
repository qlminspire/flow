namespace Flow.Application.Models.UserCategory;

public sealed record UserCategoryDto
{
    public required Guid Id { get; init; }

    public required string Name { get; init; }
}