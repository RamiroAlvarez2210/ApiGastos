using ApiGastos.Domain.Entities;
using ApiGastos.Infrastructure.Data;

using ApiGastos.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace ApiGastos.API.Services;

public class MovimientoService : IMovimientoService
{
    private readonly GastosDbContext _context;
    public MovimientoService(GastosDbContext context)
    {
        _context = context;
    }
    public void AgregarMovimiento(DateTime fecha, decimal monto, string tipo, int idUsuario, string descripcion)
    {
        var movimiento = new Movimiento
        {
            Fecha = fecha,
            ID_Usuario = idUsuario,
            Monto = monto,
            TipoMovimiento = tipo,
            Activo = true,
            FechaAlta = DateTime.Now,
            Descripcion = descripcion
        };
        _context.Movimientos.Add(movimiento);
        ActualizarSaldoAhorro(monto, tipo, idUsuario);
        _context.SaveChanges();
    }
    public void AgregarAhorro(string moneda, bool plazo, int idMovimiento)
    {
        var ahorro = new Ahorro
        {
            Moneda = moneda,
            Plazo = plazo,
            ID_Movimiento = idMovimiento
        };
        _context.Ahorros.Add(ahorro);
        _context.SaveChanges();
    }
    public void AgregarCuota(int nroCuota, bool pagado, string mesPagar, string tarjeta, int idProxCuota, int idMovimiento)
    {
        var cuota = new Cuota
        {
            NroCuota = nroCuota,
            Pagado = pagado,
            MesPagar = mesPagar,
            Tarjeta = tarjeta,
            ID_ProximaCuota = idProxCuota
        };
        _context.Cuotas.Add(cuota);
        _context.SaveChanges();
    }
    public void AgregarFechaCierre(DateTime cierre, DateTime vencimiento, string tarjeta, int idUsuario)
    {
        var fechaC = new FechaCierre
        {
            Cierre = cierre,
            Vencimiento = vencimiento,
            Tarjeta = tarjeta,
            ID_Usuario = idUsuario
        };
        _context.FechasCierre.Add(fechaC);
        _context.SaveChanges();
    }
    public void AgregarGasto(string categoria, bool recurrente, int tiempoRecurrencia, int idMovimiento)
    {
        var gasto = new Gasto
        {
            Categoria = categoria,
            esRecurrente = recurrente,
            TiempoRecurrencia = tiempoRecurrencia,
            ID_Movimiento = idMovimiento
        };
        _context.Gastos.Add(gasto);
        _context.SaveChanges();
    }
    public void AgregarReintegro(string tipoOrigen, int idMovimiento)
    {
        var reintegro = new Reintegro
        {
            TipoOrigen = tipoOrigen,
            ID_Movimiento = idMovimiento
        };
        _context.Reintegros.Add(reintegro);
        _context.SaveChanges();
    }
    public int UltimoMovimiento(string tipo)
    {
        return _context.Movimientos
                    .Where(m => m.TipoMovimiento == tipo)
                    .Select(m => m.ID_Movimiento)
                    .Max();
    }
    public IEnumerable<decimal> ObtenerMovimientos(int idUsuario)
    {
        return _context.Movimientos
                   .Where(m => m.ID_Usuario == idUsuario)
                   .Select(m => m.Monto)
                   .ToList();
    }
    public void ActualizarSaldoAhorro(decimal monto, string tipoMovimiento, int idUsuario)
    {
        int tipo = TipoMovimientoHelper.ObtenerCodigoDesdeTexto(tipoMovimiento);
        var usuario = _context.Usuarios.Where(u => u.ID_Usuario == idUsuario).FirstOrDefault();
        if (usuario != null)
        {
            Console.WriteLine($"El tipo es numero {tipo} y el usuario {usuario.ID_Usuario}");
            if (tipo == 0)
            {
                usuario.Saldo += monto; // puede ser positivo o negativo para ajuste
                return;
            }
            if (tipo == 1)
            {
                usuario.Saldo += monto;  // solo positivo para reintegro
                return;
            }
            else
            {
                usuario.Saldo -= monto; // solo positivo para Gasto, Cuota, Ahorro
            }
        }
    }
    public decimal GastoXFiltro(DateTime fechaInicial, DateTime fechaFinal)
    {
        /*
        var date = new DateTime(2025, 10, 18);
        var next = date.AddDays(1);
        var total = _context.Movimientos
            .Where(m => m.Fecha >= date && m.Fecha < next)
            .Sum(m => m.Monto);
        // Use the result as needed (here we just log it)
        Console.WriteLine($"Total gasto el {date:yyyy-MM-dd}: {total}");
        */
        //var date = new DateTime(2025, 10, 18);
        var total = _context.Movimientos
            .Where(m => m.Fecha >= fechaInicial || m.Fecha <= fechaFinal)
            .Sum(m => m.Monto);
        return total;
    }
}
