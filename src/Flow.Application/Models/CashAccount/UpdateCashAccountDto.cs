﻿namespace Flow.Application.Models.CashAccount;

public sealed record UpdateCashAccountDto(string Name, decimal Amount, Guid CurrencyId, Guid? CategoryId = null);