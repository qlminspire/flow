namespace Flow.Api.Models.Subscription;

public sealed record SubscriptionResponse(Guid Id, string Service, decimal Price, string Currency, int PaymentPeriod, DateTimeOffset? PaymentDate, bool IsActive);
