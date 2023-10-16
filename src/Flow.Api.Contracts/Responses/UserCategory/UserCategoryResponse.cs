namespace Flow.Api.Contracts.Responses.UserCategory;

public sealed record UserCategoryResponse
{
    public Guid Id { get; init; }

    public string Name { get; init; }

    public string? Description { get; init; }
}
