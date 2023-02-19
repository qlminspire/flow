using Flow.Entities.Core.Enums;

namespace Flow.Business.Models.BankDeposit;

public sealed record UpdateBankDepositDto(decimal Amount, Guid CurrencyId, double Rate, DepositType Type, int PeriodInMonthes, Guid? RefundAccountId, Guid? CategoryId = null);