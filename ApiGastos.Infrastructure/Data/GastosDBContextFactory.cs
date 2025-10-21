using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ApiGastos.Infrastructure.Data
{
    public class GastosDbContextFactory : IDesignTimeDbContextFactory<GastosDbContext>
    {
        public GastosDbContext CreateDbContext(string[] args)
        {
            // Cargar configuración desde ApiGastos.API
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ApiGastos.API"))
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<GastosDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new GastosDbContext(optionsBuilder.Options);
        }
    }
}
