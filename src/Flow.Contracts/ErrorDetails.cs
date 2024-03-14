﻿using System.Text.Json;

namespace Flow.Contracts;

public sealed class ErrorDetails
{
    public required int StatusCode { get; init; }

    public string? Message { get; init; }

    public override string ToString() => JsonSerializer.Serialize(this);
}