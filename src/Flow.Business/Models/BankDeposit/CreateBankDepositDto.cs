using Flow.Entities.Core.Enums;

namespace Flow.Business.Models.BankDeposit;

public sealed record CreateBankDepositDto(decimal Amount, Guid CurrencyId, double Rate, DepositType Type, int PeriodInMonthes, Guid? RefundAccountId, Guid? CategoryId = null);