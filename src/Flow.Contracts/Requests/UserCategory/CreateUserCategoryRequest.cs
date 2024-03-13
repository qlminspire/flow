﻿namespace Flow.Contracts.Requests.UserCategory;

public sealed record CreateUserCategoryRequest
{
    public string? Name { get; init; }
}