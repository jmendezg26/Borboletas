namespace Borboletas.Entidades
{
    public class Ventas
    {
    }

    public class NuevaVenta
    {
        public string Informacion { get; set; }
        public double Total { get; set; }
        public int IdEstado { get; set; }
        public DateTime FechaVenta { get; set; }
        public int IdUsuario { get; set; }
        public int TipoMoneda { get; set; }
        public DateTime FechaCancelacion { get; set; }
        public double PesoTotal { get; set; }
        public double AbonoInicial {  get; set; }
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

    public class NuevoAbono
    {
        public int IdCuenta { get; set; }
        public double Abono { get; set; }
        public double SaldoAnterior { get; set; }
        public double NuevoSaldo { get; set; }
        public DateTime FechaRegistro { get; set; }
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
}
