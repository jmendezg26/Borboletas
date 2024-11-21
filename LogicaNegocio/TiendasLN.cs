using Borboletas.AccesoDatos;
using Borboletas.Entidades;

namespace Borboletas.LogicaNegocio
{
    public class TiendasLN
    {
        private readonly TiendasAD _TiendasAD = new TiendasAD();

        #region Metodos Obtener
        public List<Tiendas> ObtenerTiendas()
        {
            List<Tiendas> ListaTiendas = new List<Tiendas>();

            try
            {
                return ListaTiendas = _TiendasAD.ObtenerTiendas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Tiendas> ObtenerTiendasEstados()
        {
            List<Tiendas> ListaTiendas = new List<Tiendas>();

            try
            {
                return ListaTiendas = _TiendasAD.ObtenerTiendasEstados();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion Metodos Obtener

        #region Metodos Insertar
        public int AgregarTienda(Tiendas LaTienda)
        {
            int Resultado = 0;

            try
            {
                Resultado = _TiendasAD.AgregarTienda(LaTienda);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Resultado;
        }
        #endregion Metodos Insertar

        #region Metodos Editar
        public int EditarTienda(Tiendas LaTienda)
        {
            int Resultado = 0;

            try
            {
                Resultado = _TiendasAD.EditarTienda(LaTienda);
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
