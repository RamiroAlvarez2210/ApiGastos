using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGastos.Domain.Entities
{
    public class Reintegro : TipoMovimiento
    {
        [Key]
        public int ID_Reintegro { get; set; }
        public string TipoOrigen { get; set; } = string.Empty;
    }
}