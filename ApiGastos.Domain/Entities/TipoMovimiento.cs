using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApiGastos.Domain.Entities
{
    public abstract class TipoMovimiento
    {
        [ForeignKey("Movimiento")]
        public int ID_Movimiento { get; set; }
    }
}