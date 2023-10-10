using Flow.Application.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Flow.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFlowApplication(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        var currentProjectType = typeof(ServiceCollectionExtensions);
        services.AddAutoMapper(currentProjectType);
        return services;
    }
}
