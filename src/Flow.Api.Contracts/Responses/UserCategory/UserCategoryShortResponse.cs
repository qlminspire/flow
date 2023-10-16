namespace Flow.Api.Contracts.Responses.UserCategory;

public sealed record UserCategoryShortResponse
{
    public Guid Id { get; init; }

    public string Name { get; init; }
}
