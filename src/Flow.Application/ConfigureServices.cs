using Microsoft.Extensions.DependencyInjection;

namespace Flow.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var currencyProjectType = typeof(ConfigureServices);
        services.AddAutoMapper(currencyProjectType);
        return services;
    }
}
