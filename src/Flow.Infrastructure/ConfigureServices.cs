using Flow.Application.Persistence;
using Flow.Application.Services;
using Flow.Infrastructure.Persistence;
using Flow.Infrastructure.Persistence.Repositories;
using Flow.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Flow.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddTransient<IBankService, BankService>()
            .AddTransient<ICurrencyService, CurrencyService>()
            .AddTransient<ISubscriptionService, SubscriptionService>()
            .AddTransient<IBankAccountService, BankAccountService>()
            .AddTransient<ICashAccountService, CashAccountService>()
            .AddTransient<ICalculatedBalanceService, CalculatedBalanceService>()
            .AddTransient<IBankDepositService, BankDepositService>()
            .AddTransient<IAccountOperationService, AccountOperationService>()
            .AddTransient<IPlannedExpenseService, PlannedExpenseService>()
            .AddTransient<ICurrencyConversionRateService, CurrencyConversionRateService>()
            .AddTransient<IDebtService, DebtService>();

        return services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static IServiceCollection AddFlowDbContext(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsBuilder, int connectionPoolSize = 1024)
    {
        return services.AddDbContextPool<FlowContext>(optionsBuilder, connectionPoolSize);
    }
}
