using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MyApi.OperationFilters;

public class AuthorizeOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        // Policy names map to scopes
        var requiredAttributes = context.MethodInfo
            .GetCustomAttributes(true)
            .OfType<AuthorizeAttribute>()
            .Select(x => x.Policy)
            .ToList();

        if (!requiredAttributes.Any()) return;

        var existingResponse = operation.Responses.Keys.ToList();

        if (!existingResponse.Contains("401"))
            operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });

        if (!existingResponse.Contains("403"))
            operation.Responses.Add("403", new OpenApiResponse { Description = "Forbidden" });

        var oAuthScheme = new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
        };

        operation.Security = new List<OpenApiSecurityRequirement>
        {
            new OpenApiSecurityRequirement
            {
                [ oAuthScheme ] = requiredAttributes.ToList()
            }
        };
    }
}