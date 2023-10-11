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

            c.SwaggerDoc(ApiContants.Version, new OpenApiInfo
            {
                Title = SwaggerConstants.ApiTitle,
                Version = ApiContants.Version,
                Description = "The goal of this API to make personal finance tracking simple"
            });

            //c.DocumentFilter<LowerCaseDocumentFilter>();
        });

        return services;
    }
}
