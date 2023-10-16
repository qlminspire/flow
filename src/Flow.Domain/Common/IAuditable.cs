﻿namespace Flow.Domain.Common;

public interface IAuditable
{
    DateTimeOffset CreatedAt { get; set; }

    DateTimeOffset? UpdatedAt { get; set; }
}
