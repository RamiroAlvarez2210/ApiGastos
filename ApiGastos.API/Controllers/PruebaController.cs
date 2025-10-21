using Microsoft.AspNetCore.Mvc;

using ApiGastos.Infrastructure.Data;
using ApiGastos.Domain.Entities;
//using Microsoft.IdentityModel.Tokens;
//using System.Data.SqlTypes;

namespace ApiGastos.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PruebasController : ControllerBase
{/*
    private readonly GastosDbContext _context;
    
    public PruebasController(GastosDbContext context)
    {
        _context = context;
    }
    [HttpPost("altaUsuario")]
    public IActionResult AltaUsuario()
    {
        var usuario = new Usuario
        {
            Nombre = "Ramiro",
            Apellido = "Alvarez",
            Contrasena = "2210",
            Saldo = 0,
        };
        
        _context.Add(usuario);
        _context.SaveChanges();
        return Ok($"Usuario creado ");
    }
    // GET api/resumen/saldo
    [HttpGet("saldo{ID_Usuario}")]
    public IActionResult GetSaldo(int ID_Usuario)
    {
        var usuario = _context.Usuarios.Find(ID_Usuario);

        if (usuario == null)
        {
            return NotFound($"Usuario con ID {ID_Usuario} no encontrado.");
        }

        return Ok(
            usuario.Saldo
        );
    }
    [HttpGet("{id}")]
    public IActionResult obtenerMovimiento(int id)
    {
        var mov = _context.Movimientos.Find(id);

        return Ok(mov);
    }
    [HttpGet("idUsuario")]
    public IActionResult obtenerGastoMes()
    {
        //var gastos = _context.Usuarios.Where(u => u.Contrasena == "2210");
        var gastos = from u in _context.Usuarios
                     where u.ID_Usuario == 1
                     select u.Nombre;
        return Ok(gastos);
    }
    [HttpPost("{monto}/{tipo}/{idUser}")]
    public IActionResult IngresarMovimiento(decimal monto, string tipo, int idUser)
    {

        var movimiento = new Movimiento
        {
            Monto = monto,
            Activo = true,
        };
        

        _context.Add(movimiento);
        _context.SaveChanges();
        return Ok("Se cargo correctamente");
    }*/
}