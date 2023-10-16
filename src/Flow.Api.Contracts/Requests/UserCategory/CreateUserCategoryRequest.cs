namespace Flow.Api.Contracts.Requests.UserCategory;

public sealed record CreateUserCategoryRequest
{
    public string Name { get; init; }

    public string? Description { get; init; }
}
