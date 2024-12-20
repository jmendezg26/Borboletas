namespace Borboletas.Entidades
{
    public class Ventas
    {
    }

    public class TopVentas
    {
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string Telefono { get; set; }
        public int CantidadVentas { get; set; }
    }


    public class ListarVentas
    {
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public int IdTipoVenta { get; set; }
        public string TipoVenta { get; set; }
        public string Informacion { get; set; }
        public double Total { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public DateTime FechaVenta { get; set; }
        public int IdUsuario { get; set; }
        public string Vendedor { get; set; }
        public int TipoMoneda { get; set; }
        public DateTime? FechaCancelacion { get; set; }
        public double PesoTotal { get; set; }
    }

    public class NuevaVenta
    {
        public string Informacion { get; set; }
        public double Total { get; set; }
        public int IdEstado { get; set; }
        public DateTime FechaVenta { get; set; }
        public int IdUsuario { get; set; }
        public int TipoMoneda { get; set; }
        public DateTime? FechaCancelacion { get; set; }
        public double PesoTotal { get; set; }
        public double AbonoInicial { get; set; }
        public int IdCliente { get; set; }
        public int IdTipoVenta { get; set; }
        public List<ArticulosDeVenta> ListaArticulo { get; set; }

    }

    public class NuevaCuentaXCobrar
    {
        public int IdVenta { get; set; }
        public double SaldoPendiente { get; set; }
        public int IdEstado { get; set; }
    }

    public class CuentasXCobrar
    {
        public int IdCuentaXCobrar { get; set; }
        public int IdVenta { get; set; }
        public double SaldoPendiente { get; set; }
        public int IdEstado { get; set; }
    }

    public class EditarCuentaXCobrar
    {
        public int IdCuenta { get; set; }
        public double SaldoAnterior { get; set; }
        public double NuevoSaldo { get; set; }
        public int IdEstado { get; set; }
        public double Abono { get; set; }
    }

    public class NuevoAbono
    {
        public int IdCuenta { get; set; }
        public double Abono { get; set; }
        public double SaldoAnterior { get; set; }
        public double NuevoSaldo { get; set; }
        public int IdUsuario { get; set; }
    }

    public class Abonos
    {
        public int IdAbono { get; set; }
        public int IdCuenta { get; set; }
        public double Abono { get; set; }
        public double SaldoAnterior { get; set; }
        public double NuevoSaldo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdUsuario { get; set; }
    }

    public class ArticulosDeVenta
    {
        public int IdVenta { get; set; }
        public string Articulo { get; set; }
        public int IdTienda { get; set; }
        public double Peso { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
    }

    public class HistorialAbonosXIdCliente
    {
        public int IdCliente { get; set; }
        public int IdCuenta { get; set; }
        public double SaldoPendiente { get; set; }
        public double MontoTotal { get; set; }
        public double Abono { get; set; }
        public DateTime FechaAbono { get; set; }
    }

    public class HistorialComprasXIdCliente
    {
        public int IdCliente { get; set; }
        public int IdCuenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public string Articulos { get; set; }
        public double MontoTotal { get; set; }
        public double SaldoPendiente { get; set; }
        public DateTime? FechaCancelacion { get; set; }
        public int IdTipoVenta { get; set; }
        public int IdEstadoVenta { get; set; }
        public int TipoMoneda { get; set; }
        public int IdVenta { get; set; }

    }

    public class HistorialComprasGeneral
    {
        public int IdCliente { get; set; }
        public int IdCuenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public string Articulos { get; set; }
        public double MontoTotal { get; set; }
        public double SaldoPendiente { get; set; }
        public DateTime? FechaCancelacion { get; set; }
        public int IdTipoVenta { get; set; }
        public int IdEstadoVenta { get; set; }
        public int TipoMoneda { get; set; }
        public string NombreCliente { get; set; }
    }

    public class HistorialComprasTiendas
    {
        public DateTime FechaVenta { get; set; }
        public string Tienda { get; set; }
        public string Articulo { get; set; }
        public string Cliente { get; set; }
    }

    public class DetalleVenta
    {
        public string Articulo { get; set; }
        public string Tienda { get; set; }
        public double Peso { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
    }

    public class HistorialCuentasXCobrar
    {
        public int IdCuenta { get; set; }
        public int IdVenta { get; set; }
        public double SaldoPendiente { get; set; }
        public int IdEstado { get; set; }
        public string Informacion { get; set; }
        public double TotalVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public string Vendedor { get; set; }
        public int TipoMoneda { get; set; }
        public DateTime FechaCancelacion { get; set; }
        public double PesoTotal { get; set; }
        public int IdCliente { get; set; }
        public string Cliente { get; set; }
        public string Articulos { get; set; }

    }

}
