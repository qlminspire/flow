﻿using Flow.Application.Models.Bank;
using Flow.Application.Models.Currency;
using Flow.Application.Models.UserCategory;

namespace Flow.Application.Models.BankAccount;

public sealed class BankAccountDto
{
    public Guid Id { get; init; }

    public string Iban { get; init; }

    public BankDto Bank { get; init; }

    public decimal Amount { get; init; }

    public CurrencyDto Currency { get; init; }

    public UserCategoryDto? Category { get; init; }
}
