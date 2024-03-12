﻿using Flow.Domain.Currencies;

namespace Flow.Domain.UserPreferences;

public sealed class UserPreferences : Entity, IAuditable
{
    public Guid CurrencyId { get; set; }

    public Currency? Currency { get; set; }

    public int BudgetingStartDay { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}