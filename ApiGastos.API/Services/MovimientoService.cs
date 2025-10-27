using ApiGastos.Domain.Entities;
using ApiGastos.Infrastructure.Data;

using ApiGastos.Domain.Enums;
using Microsoft.EntityFrameworkCore;

using System.Text.RegularExpressions;

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
        // AGREGAR VERIFICACION DE MONTO POR TIPO DE MOVIMIENTO
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
        Console.WriteLine("Movimiento ingresado");
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
    public void AgregarMovGalicia(string cadena, int idUsuario)
    {
        string patron = @"(?<fecha>\d{2}/\d{2}/\d{4})(?<descripcion>.+?)(?<monto>-?\$[\d.]*,\d{2})";

        MatchCollection coincidencias = Regex.Matches(cadena, patron);

        //Console.WriteLine($"Se encontraron {coincidencias.Count} movimientos:\n");

        foreach (Match m in coincidencias)
        {
            DateTime fecha = DateTime.Parse(m.Groups["fecha"].Value);
            string descripcion = m.Groups["descripcion"].Value.Trim(); // Trim para limpiar espacios extra
                                                                       // 1. Obtener el string sucio
            string montoStr = m.Groups["monto"].Value;

            // 2. Limpiarlo
            string montoLimpio = montoStr
                .Replace("$", "")      // Quita el símbolo de moneda
                .Replace(".", "")      // Quita el separador de miles
                .Replace(",", ".");    // REEMPLAZA la coma decimal por un punto decimal (formato universal)

            // 3. Convertir usando la "Cultura Invariante" (que SIEMPRE espera '.' como decimal)
            decimal monto = decimal.Parse(montoLimpio, System.Globalization.CultureInfo.InvariantCulture);
            if (monto < 0)
            {
                Math.Abs(monto);
            }
            AgregarMovimiento(fecha, monto, m.Groups["monto"].Value[0] == '-' ? "Gasto" : "Reintegro", idUsuario, descripcion);
        }
    }
    public decimal SaldoActual(int idUsuario)
    {
        //return _context.Usuarios.Where(u => u.ID_Usuario == idUsuario).Select(u => u.Saldo);
        return _context.Usuarios.Select(u => u.Saldo).FirstOrDefault();
    }
    public IEnumerable<decimal> ProfitXDias(DateTime fechaInicial, DateTime fechaFinal, int idUsuario)
    {
        var resumenPorDia = _context.Movimientos
            .Where(m => m.ID_Usuario == idUsuario && m.Fecha >= fechaInicial && m.Fecha <= fechaFinal)
            .GroupBy(m => m.Fecha.Date) // .GroupBy(m => EF.Functions.DateDiffDay(fechaInicial, m.Fecha))
            .Select(g => g.Sum(m => m.Monto))
            .ToList();
        return resumenPorDia;
    }
}
