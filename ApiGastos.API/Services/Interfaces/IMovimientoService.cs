using ApiGastos.Domain.Entities;

public interface IMovimientoService
{
    void AgregarMovimiento(DateTime Fecha, decimal monto, string tipo, int idUsuario, string descripcion);
    void AgregarAhorro(string moneda, bool Plazo, int idMovimiento);
    void AgregarCuota(int nroCuota, bool pagado, string mesPagar, string tarjeta, int idProxCuota, int idMovimiento);
    void AgregarFechaCierre(DateTime cierre, DateTime vencimiento, string tarjeta, int idUsuario);
    void AgregarGasto(string categoria, bool recurrente, int tiempoRecurrencia, int idMovimiento);
    void AgregarReintegro(string tipoOrigen, int idMovimiento);
    int UltimoMovimiento(string tipo);
    IEnumerable<decimal> ObtenerMovimientos(int usuario);
    void ActualizarSaldoAhorro(decimal monto, string tipoMovimiento, int idUsuario);
    //void CrearUsuario(string nombre, string apellido, string contrasena);
    //decimal? ObtenerSaldo(int idUsuario);
    decimal GastoXFiltro(DateTime fechaInicial, DateTime fechaFinal);
    void AgregarMovGalicia(string cadena, int idUsuario);
    decimal SaldoActual(int idUsuario);
    IEnumerable<decimal> ProfitXDias(DateTime fechaInicial, DateTime fechaFinal, int idUsuario);
}
