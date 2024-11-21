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
                IdEstado = Convert.ToInt32(Ready["IdEstado"]),
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

        public List<Tiendas> ObtenerTiendasEstados()
        {
            List<Tiendas> ListaTiendas = new List<Tiendas>();

            try
            {
                using SqlConnection conexion = new SqlConnection(_BDConnection.BD_CONEXION);

                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_ObtenerTiendasEstados";

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


        #region Metodos Crear/Insertar
        public int AgregarTienda(Tiendas LaTienda)
        {
            int Resultado = 0;

            try
            {
                using SqlConnection conexion = new SqlConnection(_BDConnection.BD_CONEXION);

                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_InsertarTienda";
                cmd.Parameters.AddWithValue("@Tienda", LaTienda.Nombre);

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
     

        #endregion Metodos Crear/Insertar

        #region Metodos Editar
        public int EditarTienda(Tiendas LaTienda)
        {
            int Resultado = 0;

            try
            {
                using SqlConnection conexion = new SqlConnection(_BDConnection.BD_CONEXION);

                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_EditarTienda";
                cmd.Parameters.AddWithValue("@IdTienda", LaTienda.IdTienda);
                cmd.Parameters.AddWithValue("@Nombre", LaTienda.Nombre);
                cmd.Parameters.AddWithValue("@IdEstado", LaTienda.IdEstado);

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
