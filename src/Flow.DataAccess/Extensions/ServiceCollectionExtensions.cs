using Flow.DataAccess.Contracts;
using Flow.DataAccess.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Flow.DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFlowDbContext(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsBuilder, int connectionPoolSize = 1024)
    {
        return services.AddDbContextPool<FlowContext>(optionsBuilder, connectionPoolSize);
    }

    public static IServiceCollection RegisterDataAccessServices(this IServiceCollection services)
    {
        return services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
