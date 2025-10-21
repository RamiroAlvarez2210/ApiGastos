using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ApiGastos.API.Config
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Gastos API",
                    Description = "API para prácticas de ASP.NET Core Web Api."
                });
            });

            return services;
        }
    }
}
