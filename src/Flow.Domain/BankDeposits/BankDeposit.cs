﻿using Flow.Domain.Accounts;
using Flow.Domain.Currencies;
using Flow.Domain.UserCategories;
using Flow.Domain.Users;

namespace Flow.Domain.BankDeposits;

public sealed class BankDeposit : Entity, IAuditable
{
    private BankDeposit()
    {
    }

    public Money Amount { get; private set; }

    public Guid CurrencyId { get; private set; }

    public Currency? Currency { get; private set; }

    public Guid UserId { get; private set; }

    public User? User { get; private set; }

    public DepositType Type { get; private set; }

    public double Rate { get; private set; }

    public int PeriodInMonths { get; private set; }

    public DateTimeOffset? EndDate { get; private set; }

    public Guid RefundAccountId { get; private set; }

    public BankAccount? RefundAccount { get; private set; }

    public Guid? CategoryId { get; private set; }

    public UserCategory? Category { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public static Result<BankDeposit> Create()
    {
        return new BankDeposit();
    }
}