﻿using System.Text.Json;

namespace Flow.Api.Models;

public sealed class ErrorDetails
{
    public int StatusCode { get; set; }

    public string? Message { get; set; }

    public override string ToString() => JsonSerializer.Serialize(this);
}
