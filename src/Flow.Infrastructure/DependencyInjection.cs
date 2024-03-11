using Flow.Infrastructure.Persistence;
using Flow.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace Flow.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton(TimeProvider.System);

        services.Scan(x =>
            x.FromAssemblies(typeof(DependencyInjection).Assembly)
                .AddClasses(filter => filter.Where(type => type.Name.EndsWith("Service", StringComparison.Ordinal)),
                    false)
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime()
        );

        services.Decorate<IBankService, CachedBankService>();

        services.AddMemoryCache();

        return services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services,
        Action<DbContextOptionsBuilder> optionsBuilder, int connectionPoolSize = 1024)
    {
        return services.AddDbContextPool<FlowContext>(optionsBuilder, connectionPoolSize);
    }
}