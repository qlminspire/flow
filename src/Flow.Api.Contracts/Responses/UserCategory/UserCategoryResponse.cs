namespace Flow.Api.Contracts.Responses.UserCategory;

public sealed record UserCategoryResponse
{
    public required Guid Id { get; init; }

    public required string Name { get; init; }

    public string? Description { get; init; }
}
