﻿namespace Flow.Api.Contracts.Requests.Subscription;

public sealed record UpdateSubscriptionRequest(string Service, decimal Price, Guid CurrencyId, int PaymentPeriod, DateTimeOffset? PaymentDate, bool IsActive);