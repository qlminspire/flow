using Microsoft.Extensions.DependencyInjection;

namespace Flow.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFlowApplication(this IServiceCollection services)
    {
        services.AddSingleton(TimeProvider.System);

        return services;
    }
}
