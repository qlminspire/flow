﻿namespace Flow.Api.Contracts.Requests.Bank;

public sealed record CreateBankRequest(string? Name, bool IsActive);
