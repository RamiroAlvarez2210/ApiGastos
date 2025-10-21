namespace ApiGastos.Domain.Enums
{
    public enum EnumTipoMovimiento
    {
        Ajuste,
        Reintegro, // saldo ++
        Ahorro, // saldo --
        Cuota, // comprobar fecha => saldo --
        Gasto // saldo --
    }

    public static class TipoMovimientoHelper
    {
        public static readonly Dictionary<string, EnumTipoMovimiento> TextoAEstado = new()
    {
        { "Ajuste", EnumTipoMovimiento.Ajuste },
        { "Reintegro", EnumTipoMovimiento.Reintegro },
        { "Ahorro", EnumTipoMovimiento.Ahorro },
        { "Cuota", EnumTipoMovimiento.Cuota },
        { "Gasto", EnumTipoMovimiento.Gasto },

    };

        public static int ObtenerCodigoDesdeTexto(string texto)
        {
            return TextoAEstado.TryGetValue(texto, out var estado)
                ? (int)estado
                : -1; // o lanzar excepción si preferís
        }
    }

}