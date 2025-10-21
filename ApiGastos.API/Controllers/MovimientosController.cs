using Microsoft.AspNetCore.Mvc;

using ApiGastos.Infrastructure.Data;
using ApiGastos.Domain.Entities;
using ApiGastos.API.Services;
namespace ApiGastos.API.Controllers;

[ApiController]
[Route("ApiGastos/[controller]")]
public class MovimientosController : ControllerBase
{
    private readonly IMovimientoService _movimientoService;
    public MovimientosController(IMovimientoService movimientoService)
    {
        _movimientoService = movimientoService;
    }
    [HttpPost]
    public IActionResult IngresarMovimiento(string fecha, decimal monto, string tipo, int idUsuario, string descripcion)
    {
        var fechaMod = new DateTime();

        int ano = DateTime.Now.Year;
        int mes = DateTime.Now.Month;


        if(fecha == null)
        {
            fechaMod = DateTime.Now;
        }
        else
        {
            // Logica para identificar cadena automaticamente
            if (fecha.Length <= 2 && int.Parse(fecha) <= DateTime.DaysInMonth(ano, mes))
            {
                fechaMod = new DateTime(ano, mes, int.Parse(fecha));

            }
            else
            {
                if (fecha.Length <= 5 && int.Parse(fecha.Substring(3)) > 0 && int.Parse(fecha.Substring(3)) <= 12 
                && int.Parse(fecha.Substring(0, 2)) <= DateTime.DaysInMonth(ano, int.Parse(fecha.Substring(3))))
                {
                    fechaMod = new DateTime(ano, int.Parse(fecha.Substring(3)), int.Parse(fecha.Substring(0, 2)));
                }
            }

        }
        _movimientoService.AgregarMovimiento(fechaMod, monto, tipo, idUsuario, descripcion);

        return Ok("Movimiento cargado correctamente.");
    }
    [HttpGet("movimiento/{idUsuario}")]
    public IActionResult ObtenerMovimientos(int idUsuario)
    {
        var mov = _movimientoService.ObtenerMovimientos(idUsuario);
        if (mov == null) return NotFound();
        return Ok(mov);
    }
    [HttpPost("Ahorro")]
    public IActionResult IngresarAhorro(string moneda, bool Plazo)
    {
        int idMovimiento = _movimientoService.UltimoMovimiento("Ahorro");
        _movimientoService.AgregarAhorro(moneda, Plazo, idMovimiento);
        return Ok();
    }
    [HttpPost("Cuota")]
    public IActionResult IngresarCuota(int nroCuota, bool pagado, string mesPagar, string tarjeta, int idProxCuota)
    {
        int idMovimiento = _movimientoService.UltimoMovimiento("Cuota");
        _movimientoService.AgregarCuota(nroCuota, pagado, mesPagar, tarjeta, idProxCuota, idMovimiento);
        return Ok();
    }
    [HttpPost("Gasto")]
    public IActionResult IngresarGasto(string categoria, bool recurrente, int tiempoRecurrencia)
    {
        int idMovimiento = _movimientoService.UltimoMovimiento("Gasto");
        _movimientoService.AgregarGasto(categoria, recurrente, tiempoRecurrencia, idMovimiento);
        return Ok();
    }
    [HttpPost("Reintegro")]
    public IActionResult IngresarReintegro(string tipoOrigen)
    {
        int idMovimiento = _movimientoService.UltimoMovimiento("Reintegro");
        _movimientoService.AgregarReintegro(tipoOrigen, idMovimiento);
        return Ok();
    }
    [HttpPost("Prueba")]
    public IActionResult pruebaa(DateTime fechaInicial, DateTime fechaFinal)
    {
        
        return Ok(_movimientoService.GastoXFiltro(fechaInicial,fechaFinal));
    }
}
