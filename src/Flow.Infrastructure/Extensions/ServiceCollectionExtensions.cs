using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Scrutor;

using Flow.Infrastructure.Persistence;
using Flow.Infrastructure.Persistence.Repositories;

namespace Flow.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFlowInfrastructure(this IServiceCollection services)
    {
        services.Scan(x =>
            x.FromAssemblies(typeof(ServiceCollectionExtensions).Assembly)
                .AddClasses(filter => filter.Where(type => type.Name.EndsWith("Service", StringComparison.Ordinal)), publicOnly: false)
                .UsingRegistrationStrategy(RegistrationStrategy.Throw)
                .AsImplementedInterfaces()
                .WithScopedLifetime()
        );

        return services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static IServiceCollection AddFlowDbContext(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsBuilder, int connectionPoolSize = 1024)
    {
        return services.AddDbContextPool<FlowContext>(optionsBuilder, connectionPoolSize);
    }
}
