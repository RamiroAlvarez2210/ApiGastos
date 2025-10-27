using Microsoft.AspNetCore.Builder;

namespace ApiGastos.API.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRedirect(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RedirectMiddleware>();
        }
    }
}
