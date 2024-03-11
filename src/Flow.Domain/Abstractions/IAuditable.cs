﻿namespace Flow.Domain.Abstractions;

public interface IAuditable
{
    DateTime CreatedAt { get; set; }

    DateTime? UpdatedAt { get; set; }
}