﻿namespace Flow.Business.Models.Subscription;

public sealed record UpdateSubscriptionDto(string Service, decimal Price, Guid CurrencyId, int PaymentPeriod, DateTimeOffset? PaymentDate, bool IsActive = true);