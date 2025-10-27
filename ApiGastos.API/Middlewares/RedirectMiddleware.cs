using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ApiGastos.API.Middlewares
{
    public class RedirectMiddleware
    {
        private readonly RequestDelegate _next;

        public RedirectMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
            if(context.Response.StatusCode == 404)
            {
                context.Response.Redirect("http://localhost:5149/swagger/index.html");
            }
            //Console.WriteLine($"➡️ {context.Request.Method} {context.Request.Path}");
            //Console.WriteLine($"⬅️ {context.Response.StatusCode}");
        }
    }
}
