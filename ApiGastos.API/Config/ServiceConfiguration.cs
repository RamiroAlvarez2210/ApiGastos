using ApiGastos.API.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ApiGastos.API.Config
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Gastos API",
                    Description = "API para prácticas de ASP.NET Core Web Api.",
                    TermsOfService = new Uri("https://example.com/terms")
                });
            });
        }
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IMovimientoService, MovimientoService>();
            return services;
        }
    }
}