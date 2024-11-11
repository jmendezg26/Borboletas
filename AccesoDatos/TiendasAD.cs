using Borboletas.Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Borboletas.AccesoDatos
{
    public class TiendasAD
    {
        private readonly BDConexion _BDConnection = new BDConexion();

        #region Carga de Datos
        private Tiendas CargaTiendas(IDataReader Ready)
        {
            return new Tiendas
            {
                IdTienda = Convert.ToInt32(Ready["IdTienda"]),
                Nombre = Convert.ToString(Ready["Nombre"]),
            };
        }
        #endregion Carga de Datos

        #region Metodos Obtener
        public List<Tiendas> ObtenerTiendas()
        {
            List<Tiendas> ListaTiendas = new List<Tiendas>();

            try
            {
                using SqlConnection conexion = new SqlConnection(_BDConnection.BD_CONEXION);

                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_ObtenerTiendas";

                SqlDataReader DsReader = cmd.ExecuteReader();

                while (DsReader.Read())
                {
                    ListaTiendas.Add(CargaTiendas(DsReader));
                }

                conexion.Close();

                return ListaTiendas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion Metodos Obtener
    }
}
