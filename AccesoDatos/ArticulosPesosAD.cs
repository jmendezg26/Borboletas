using Borboletas.Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Borboletas.AccesoDatos
{
    public class ArticulosPesosAD
    {
        private readonly BDConexion _BDConnection = new BDConexion();

        #region CargaDatos
        private ArticulosPesos CargaArticulosPesos(IDataReader Ready)
        {
            return new ArticulosPesos
            {
                IdArticulo = Convert.ToInt32(Ready["IdArticulo"]),
                Articulo = Convert.ToString(Ready["Articulo"]),
                Peso = Convert.ToDouble(Ready["Peso"]),
                Link = Convert.ToString(Ready["Link"]),
            };
        }
        #endregion CargaDatos

        #region Metodos Obtener
        public List<ArticulosPesos> ObtenerCatalogoArticulos()
        {
            List<ArticulosPesos> ListaArticulos = new List<ArticulosPesos>();

            try
            {
                using SqlConnection conexion = new SqlConnection(_BDConnection.BD_CONEXION);

                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_ObtenerArticulosPesos";

                SqlDataReader DsReader = cmd.ExecuteReader();

                while (DsReader.Read())
                {
                    ListaArticulos.Add(CargaArticulosPesos(DsReader));
                }

                conexion.Close();

                return ListaArticulos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion Metodos Obtener

        #region Metodos Insertar
        public int AgregarArticuloCatalogo(ArticulosPesos ElArticulo)
        {
            int Resultado = 0;

            try
            {
                using SqlConnection conexion = new SqlConnection(_BDConnection.BD_CONEXION);

                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_InsertarArticuloPeso";
                cmd.Parameters.AddWithValue("@Articulo", ElArticulo.Articulo);
                cmd.Parameters.AddWithValue("@Peso", ElArticulo.Peso);
                cmd.Parameters.AddWithValue("@Link", string.IsNullOrEmpty(ElArticulo.Link) ? (object)DBNull.Value : ElArticulo.Link);


                cmd.Parameters.Add("@ID", SqlDbType.BigInt);
                cmd.Parameters["@ID"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                Resultado = Convert.ToInt32(cmd.Parameters["@ID"].Value);

                conexion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Resultado;
        }
        #endregion Metodos Insertar

        #region Metodos Editar
        public int EditarArticulo(ArticulosPesos ElArticulo)
        {
            int Resultado = 0;

            try
            {
                using SqlConnection conexion = new SqlConnection(_BDConnection.BD_CONEXION);

                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_EditarArticuloPeso";
                cmd.Parameters.AddWithValue("@IdArticulo", ElArticulo.IdArticulo);
                cmd.Parameters.AddWithValue("@Articulo", ElArticulo.Articulo);
                cmd.Parameters.AddWithValue("@Peso", ElArticulo.Peso);
                cmd.Parameters.AddWithValue("@Link", string.IsNullOrEmpty(ElArticulo.Link) ? (object)DBNull.Value : ElArticulo.Link);

                cmd.Parameters.Add("@Resultado", SqlDbType.BigInt);
                cmd.Parameters["@Resultado"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                Resultado = Convert.ToInt32(cmd.Parameters["@Resultado"].Value);

                conexion.Close();
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
