﻿namespace Flow.Business.Models.Subscription;

public sealed class SubscriptionDto
{
    public Guid Id { get; set; }

    public string Service { get; set; }

    public decimal Price { get; set; }

    public string Currency { get; set; }

    public int PaymentPeriod { get; set; }

    public DateTimeOffset? PaymentDate { get; set; }

    public bool IsActive { get; set; }
}