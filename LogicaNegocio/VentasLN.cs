using Borboletas.AccesoDatos;
using Borboletas.Entidades;

namespace Borboletas.LogicaNegocio
{
    public class VentasLN
    {
        private readonly VentasAD _VentasAD = new VentasAD();

        #region Metodos Obtener
        public List<ListarVentas> ObtenerVentas()
        {
            List<ListarVentas> ListaDeVentas = new List<ListarVentas>();

            try
            {
                return ListaDeVentas = _VentasAD.ObtenerVentas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<HistorialAbonosXIdCliente> HistorialAbonosXIdClienteIdCuenta(int IdCliente, int IdCuenta)
        {
            List<HistorialAbonosXIdCliente> HistorialAbonos = new List<HistorialAbonosXIdCliente>();

            try
            {
                return HistorialAbonos = _VentasAD.HistorialAbonosXIdClienteIdCuenta(IdCliente, IdCuenta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<HistorialComprasXIdCliente> HistorialComprasXIdCliente(int IdCliente)
        {
            List<HistorialComprasXIdCliente> HistorialCompras = new List<HistorialComprasXIdCliente>();

            try
            {
                return HistorialCompras = _VentasAD.HistorialComprasXIdCliente(IdCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<HistorialComprasTiendas> ObtenerHistorialComprasTiendas()
        {
            List<HistorialComprasTiendas> HistorialCompras = new List<HistorialComprasTiendas>();

            try
            {
                return HistorialCompras = _VentasAD.ObtenerHistorialComprasTiendas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion Metodos Obtener

        #region Metodos Insertar
        public int AgregarVenta(NuevaVenta LaVenta)
        {
            int Venta = 0;

            try
            {
                Venta = _VentasAD.AgregarVenta(LaVenta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Venta;
        }

        public int AgregarAbono(NuevoAbono ElAbono)
        {
            int Abono = 0;

            try
            {
                Abono = _VentasAD.AgregarAbono(ElAbono);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Abono;
        }

        public int AgregarCuentaXCobrar(NuevaCuentaXCobrar LaCuenta)
        {
            int Abono = 0;

            try
            {
                Abono = _VentasAD.AgregarCuentaXCobrar(LaCuenta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Abono;
        }
        #endregion Metodos Insertar

        #region Metodos Editar
        public int EditarCuentaXCobrar(EditarCuentaXCobrar LaCuenta)
        {
            int Resultado = 0;

            try
            {
                Resultado = _VentasAD.EditarCuentaXCobrar(LaCuenta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Resultado;
        }
        #endregion Metodos Editar
    }
}
