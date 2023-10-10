namespace Flow.Api.Contracts.Responses.Subscription;

public sealed record SubscriptionResponse(Guid Id, string Service, decimal Price, string Currency, int PaymentPeriod, DateTimeOffset? PaymentDate, bool IsActive);
