using ApiGastos.API.Config;
using ApiGastos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiGastos.Builder
{
    public class BuilderClass
    {
        public WebApplication Builder(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.ConfigureServices(); // 👈 Llamada al método externo
            builder.Services.AddApplicationServices();
            builder.Services.AddDbContext<GastosDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            

            //var app = builder.Build();
            return builder.Build();
        }
    }
}
