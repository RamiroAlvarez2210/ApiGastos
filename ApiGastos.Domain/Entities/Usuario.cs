using System.ComponentModel.DataAnnotations;

namespace ApiGastos.Domain.Entities
{
    public class Usuario
    {
        [Key]
        public int ID_Usuario { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Contrasena { get; set; }
        public decimal Saldo { get; set; } = 0;
        public decimal AhorrosPesos { get; set; } = 0;
        public decimal AhorrosDolares { get; set; } = 0;
        public ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
        public ICollection<FechaCierre> FechasCierre { get; set; } = new List<FechaCierre>();
    }
}
