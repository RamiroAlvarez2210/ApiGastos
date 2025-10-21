using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGastos.Domain.Entities
{
    public class Ahorro : TipoMovimiento
    {
        [Key]
        public int ID_Ahorro { get; set;}
        public string? Moneda { get; set; }
        public bool Plazo { get; set; }
    }
}