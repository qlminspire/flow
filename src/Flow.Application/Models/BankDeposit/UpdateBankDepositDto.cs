using Flow.Domain.Enums;

namespace Flow.Application.Models.BankDeposit;

public sealed record UpdateBankDepositDto(decimal Amount, Guid CurrencyId, double Rate, DepositType Type, int PeriodInMonthes, Guid? RefundAccountId, Guid? CategoryId = null);