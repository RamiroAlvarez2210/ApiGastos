using System.ComponentModel.DataAnnotations; // KEY
using System.ComponentModel.DataAnnotations.Schema; //FK
namespace ApiGastos.Domain.Entities;


public class Gasto : TipoMovimiento
{

    [Key]
    public int ID_Gasto { get; set; }
    public string Categoria { get; set; }  = string.Empty;
    public bool esRecurrente { get; set; }
    public int TiempoRecurrencia { get; set; }
    
}

