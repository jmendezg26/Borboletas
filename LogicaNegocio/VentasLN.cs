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
        #endregion Metodos Insertar
    }
}
