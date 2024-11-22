using Borboletas.AccesoDatos;
using Borboletas.Entidades;

namespace Borboletas.LogicaNegocio
{
    public class ArticulosPesosLN
    {
        private readonly ArticulosPesosAD _ArticulosPesosAD = new ArticulosPesosAD();

        #region Metodos Obtener
        public List<ArticulosPesos> ObtenerCatalogoArticulos()
        {
            List<ArticulosPesos> ListaArticulos = new List<ArticulosPesos>();

            try
            {
                return ListaArticulos = _ArticulosPesosAD.ObtenerCatalogoArticulos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion Metodos Obtener

        #region Metodos Insertar/Crear
        public int AgregarArticuloCatalogo(ArticulosPesos ElArticulo)
        {
            int Resultado = 0;

            try
            {
                Resultado = _ArticulosPesosAD.AgregarArticuloCatalogo(ElArticulo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Resultado;
        }
        #endregion Metodos Insertar/Crear

        #region Metodos Editar
        public int EditarArticulo(ArticulosPesos ElArticulo)
        {
            int Resultado = 0;

            try
            {
                Resultado = _ArticulosPesosAD.EditarArticulo(ElArticulo);
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
