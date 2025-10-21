
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApiGastos.Domain.Entities
{
    public class Cuota : TipoMovimiento
    {
        [Key]
        public int ID_Cuota { get; set; }
        public int NroCuota { get; set; }
        public bool Pagado { get; set; }
        public string MesPagar { get; set; } = string.Empty;
        public string Tarjeta { get; set; } = string.Empty;
        [ForeignKey("Proxima Cuota")]
        public int ID_ProximaCuota { get; set; }
    }
}