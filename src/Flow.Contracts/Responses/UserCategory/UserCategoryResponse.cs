namespace Flow.Contracts.Responses.UserCategory;

public sealed record UserCategoryResponse
{
    public required Guid Id { get; init; }

    public required string Name { get; init; }
}