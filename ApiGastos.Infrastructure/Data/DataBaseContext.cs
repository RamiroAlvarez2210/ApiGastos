/*using ApiGastos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiGastos.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<Reintegro> Reintegros { get; set; }
}

}
*/
using Microsoft.EntityFrameworkCore;
using ApiGastos.Domain.Entities; // si usás capa de dominio

namespace ApiGastos.Infrastructure.Data
{
    public class GastosDbContext : DbContext
    {
        public GastosDbContext(DbContextOptions<GastosDbContext> options)
            : base(options)
        {
        }

        // Tablas
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<FechaCierre> FechasCierre { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<Cuota> Cuotas { get; set; }
        public DbSet<Ahorro> Ahorros { get; set; }
        public DbSet<Reintegro> Reintegros { get; set; }
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relaciones 1:1 explícitas
            modelBuilder.Entity<Gasto>()
                .HasOne<Movimiento>()
                .WithOne()
                .HasForeignKey<Gasto>(g => g.ID_Movimiento);

            modelBuilder.Entity<Cuota>()
                .HasOne<Movimiento>()
                .WithOne()
                .HasForeignKey<Cuota>(c => c.ID_Movimiento);

            modelBuilder.Entity<Ahorro>()
                .HasOne<Movimiento>()
                .WithOne()
                .HasForeignKey<Ahorro>(a => a.ID_Movimiento);

            modelBuilder.Entity<Reintegro>()
                .HasOne<Movimiento>()
                .WithOne()
                .HasForeignKey<Reintegro>(r => r.ID_Movimiento);
            modelBuilder.Entity<Movimiento>()
                .Property(m => m.Monto)
                .HasPrecision(18, 2); // 18 dígitos, 2 decimales
        
        }
        */
    }
}
