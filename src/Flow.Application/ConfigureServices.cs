using Flow.Application.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Flow.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        var currentProjectType = typeof(ConfigureServices);
        services.AddAutoMapper(currentProjectType);
        return services;
    }
}
