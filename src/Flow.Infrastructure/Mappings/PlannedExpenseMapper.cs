using Flow.Application.Models.PlannedExpense;
using Flow.Domain.Currencies;
using Flow.Domain.PlannedExpenses;
using Riok.Mapperly.Abstractions;

namespace Flow.Infrastructure.Mappings;

[Mapper]
internal partial class PlannedExpenseMapper
{
    public partial PlannedExpenseDto Map(PlannedExpense plannedExpense);

    public partial List<PlannedExpenseDto> Map(List<PlannedExpense> plannedExpense);

    public partial List<MonthlyPlannedExpenseDto> MapToMonthlyPlannedExpenseDtos(List<PlannedExpense> plannedExpenses);

    private static string PlannedExpenseNameToString(PlannedExpenseName plannedExpenseName) => plannedExpenseName.Value;

    private static decimal MoneyToDecimal(Money money) => money.Value;

    private static string CurrencyToCurrencyCodeString(Currency currency) => currency.Code.Value;
}