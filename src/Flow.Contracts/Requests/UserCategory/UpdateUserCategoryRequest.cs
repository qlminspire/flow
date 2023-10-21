namespace Flow.Contracts.Requests.UserCategory;

public sealed record UpdateUserCategoryRequest
{
    public string? Name { get; init; }

    public string? Description { get; init; }
}
