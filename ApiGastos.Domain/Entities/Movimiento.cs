using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApiGastos.Domain.Entities
{
    public class Movimiento
    {
        [Key]
        public int ID_Movimiento { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public bool Activo { get; set; }
        public string TipoMovimiento { get; set; } = string.Empty;
        public int ID_Usuario { get; set; }
        [ForeignKey("ID_Usuario")]
        public Usuario? Usuario { get; set; }
        public int? ID_MovimientoAnterior { get; set; }
        [ForeignKey("ID_MovimientoAnterior")]
        public Movimiento? movimiento { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}