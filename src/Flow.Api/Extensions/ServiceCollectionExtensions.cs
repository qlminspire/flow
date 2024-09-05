using System.Reflection;
using Microsoft.OpenApi.Models;

namespace Flow.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFlowSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);

            c.SwaggerDoc(ApiConstants.Version, new OpenApiInfo
            {
                Title = ApiConstants.Swagger.ApiTitle,
                Version = ApiConstants.Version,
                Description = "The goal of this API to make personal finance tracking simple"
            });
        });

        return services;
    }
}