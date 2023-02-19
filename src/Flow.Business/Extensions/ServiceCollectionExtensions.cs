using Flow.Business.Services;
using Flow.Business.Services.Implementations;

using Microsoft.Extensions.DependencyInjection;

namespace Flow.Business.Extensions;

public static class ServiceCollectionExtensions
{
    //private const string ServicePostfix = "Service";

    public static IServiceCollection RegisterBusinessServices(this IServiceCollection services)
    {
        var currencyProjectType = typeof(ServiceCollectionExtensions);

        services.AddAutoMapper(currencyProjectType);

        services.AddTransient<IBankService, BankService>()
                .AddTransient<ICurrencyService, CurrencyService>()
                .AddTransient<ISubscriptionService, SubscriptionService>()
                .AddTransient<IBankAccountService, BankAccountService>()
                .AddTransient<ICashAccountService, CashAccountService>()
                .AddTransient<ICalculatedBalanceService, CalculatedBalanceService>()
                .AddTransient<IBankDepositService, BankDepositService>()
                .AddTransient<IAccountOperationService, AccountOperationService>();

        return services;

        //return services.RegisterTypesEndsWith(currencyProjectType.Assembly, ServicePostfix);
    }

    //private static Type[] GetTypesEndsWith(Assembly assembly, string postfix)
    //{
    //    var interfaces = assembly.GetTypes().Distinct().Where(x => x.Name.EndsWith(postfix) && !x.IsClass && x.IsAbstract);
    //    //var implementations = interfaces.Select(x => x);
    //    //return int;
    //}

    //private static IServiceCollection RegisterTypesEndsWith(this IServiceCollection services, Assembly assembly, string postfix)
    //{
    //    var types = GetTypesEndsWith(assembly, postfix);

    //    foreach (var type in types)
    //        services.AddTransient()

    //    return services;
    //}
}
