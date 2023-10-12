using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace Flow.Api.Swagger;

public sealed class LowerCaseDocumentFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var dictionaryPath = swaggerDoc.Paths.ToDictionary(x => ToLowercase(x.Key), x => x.Value);
        var newPaths = new OpenApiPaths();
        foreach (var path in dictionaryPath)
        {
            newPaths.Add(path.Key, path.Value);
        }
        swaggerDoc.Paths = newPaths;
    }

    private static string ToLowercase(string key)
    {
        var parts = key.Split('/').Select(part => part.Contains('}', StringComparison.Ordinal) ? part : part.ToLowerInvariant());
        return string.Join('/', parts);
    }
}
