using System.Text.Json;

namespace Flow.Api.Models;

public sealed class ErrorDetails
{
    public required int StatusCode { get; init; }

    public string? Message { get; init; }

    public override string ToString() => JsonSerializer.Serialize(this);
}