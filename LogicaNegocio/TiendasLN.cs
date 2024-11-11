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
        #endregion Metodos Obtener
    }
}
