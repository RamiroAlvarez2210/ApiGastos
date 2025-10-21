using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGastos.Domain.Entities
{
    public class FechaCierre : TipoMovimiento
    {
        [Key]
        //public int ID_Cierre { get; set; }
        public DateTime Cierre { get; set; }
        public DateTime Vencimiento { get; set; }
        public string Tarjeta { get; set; } = string.Empty;

        [ForeignKey("Usuario")]
        public int ID_Usuario { get; set; }
    }
}