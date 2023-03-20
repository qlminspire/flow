using Flow.Domain.Enums;

namespace Flow.Api.Models.BankDeposit;

public sealed record CreateBankDepositRequest(decimal Amount, Guid CurrencyId, double Rate, DepositType Type, int PeriodInMonthes, Guid? RefundAccountId, Guid? CategoryId = null);
