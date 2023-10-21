namespace Flow.Api.Contracts.Responses.UserCategory;

public sealed record UserCategoryShortResponse
{
    public required Guid Id { get; init; }

    public required string Name { get; init; }
}
