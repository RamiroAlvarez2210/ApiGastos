using ApiGastos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiGastos.Builder
{
    public static class DataBaseConfig
    {
        public static void DBConfig(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<GastosDbContext>();
            db.Database.Migrate();
        }
    }
}



/*using ApiGastos.Data;
using ApiGastos.Models;

public static class DataBaseConfig
{
    public static void DBConfig(WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            db.Database.EnsureCreated();

            if (!db.Gastos.Any() && !db.Reintegros.Any())
            {
                db.Gastos.AddRange(
                    new Gasto { numero = "001", fecha = DateTime.Now, monto = 1000, categoria = "Subte", Id = 1 }
                //new Gasto { categoria = "Supermercado", monto = 5000, EsReintegro = false, fecha = DateTime.Now }
                //new Gasto { categoria = "Reintegro empresa", monto = 2000, EsReintegro = true, fecha = DateTime.Now }
                );
                db.Reintegros.AddRange(
                    new Reintegro { numero = "001", fecha = DateTime.Now, monto = 500, categoria = "Subte", idReintegro = 1 }
                );
                db.SaveChanges();
            }
        }
    }
}

*/