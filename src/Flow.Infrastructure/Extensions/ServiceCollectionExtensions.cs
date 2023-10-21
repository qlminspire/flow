using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Scrutor;

using Flow.Infrastructure.Persistence;
using Flow.Infrastructure.Services;

namespace Flow.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFlowInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton(TimeProvider.System);
        
        services.Scan(x =>
            x.FromAssemblies(typeof(ServiceCollectionExtensions).Assembly)
                .AddClasses(filter => filter.Where(type => type.Name.EndsWith("Service", StringComparison.Ordinal)), publicOnly: false)
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime()
        );

        services.Decorate<IBankService, CachedBankService>();

        return services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static IServiceCollection AddFlowDbContext(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsBuilder, int connectionPoolSize = 1024)
    {
        services.AddMemoryCache();
        
        return services.AddDbContextPool<FlowContext>(optionsBuilder, connectionPoolSize);
    }
}
