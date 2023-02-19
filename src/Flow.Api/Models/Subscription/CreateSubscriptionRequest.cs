﻿namespace Flow.Api.Models.Subscription;

public sealed record CreateSubscriptionRequest(string Service, decimal Price, Guid CurrencyId, int PaymentPeriod, DateTimeOffset? PaymentDate, bool IsActive = true);