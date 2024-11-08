using Borboletas.Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Borboletas.AccesoDatos
{
    public class ClientesAD
    {
        private readonly BDConexion _BDConnection = new BDConexion();

        #region Metodos Obtener
        #endregion Metodos Obtener

        #region Metodos Crear/Insertar
        public int AgregarCliente(NuevoCliente ElCliente)
        {
            int Resultado = 0;

            try
            {
                using SqlConnection conexion = new SqlConnection(_BDConnection.BD_CONEXION);

                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_InsertarCliente";
                cmd.Parameters.AddWithValue("@Nombre", ElCliente.Nombre);
                cmd.Parameters.AddWithValue("@Cedula", ElCliente.Cedula);
                cmd.Parameters.AddWithValue("@Telefono", string.IsNullOrEmpty(ElCliente.Telefono) ? (object)DBNull.Value : ElCliente.Telefono);
                cmd.Parameters.AddWithValue("@TelefonoSecundario", string.IsNullOrEmpty(ElCliente.TelefonoSecundario) ? (object)DBNull.Value : ElCliente.TelefonoSecundario);
                cmd.Parameters.AddWithValue("@Provincia", string.IsNullOrEmpty(ElCliente.Provincia) ? (object)DBNull.Value : ElCliente.Provincia);
                cmd.Parameters.AddWithValue("@Canton", string.IsNullOrEmpty(ElCliente.Canton) ? (object)DBNull.Value : ElCliente.Canton);
                cmd.Parameters.AddWithValue("@Distrito", string.IsNullOrEmpty(ElCliente.Distrito) ? (object)DBNull.Value : ElCliente.Distrito);
                cmd.Parameters.AddWithValue("@Direccion", ElCliente.Direccion);

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

        public int EditarCliente(EditarCliente ElCliente)
        {
            int Resultado = 0;

            try
            {
                using SqlConnection conexion = new SqlConnection(_BDConnection.BD_CONEXION);

                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_ModificarCliente";
                cmd.Parameters.AddWithValue("@IdCliente", ElCliente.IdCliente);
                cmd.Parameters.AddWithValue("@Nombre", ElCliente.Nombre);
                cmd.Parameters.AddWithValue("@Cedula", ElCliente.Cedula);
                cmd.Parameters.AddWithValue("@Telefono", string.IsNullOrEmpty(ElCliente.Telefono) ? (object)DBNull.Value : ElCliente.Telefono);
                cmd.Parameters.AddWithValue("@TelefonoSecundario", string.IsNullOrEmpty(ElCliente.TelefonoSecundario) ? (object)DBNull.Value : ElCliente.TelefonoSecundario);
                cmd.Parameters.AddWithValue("@Provincia", string.IsNullOrEmpty(ElCliente.Provincia) ? (object)DBNull.Value : ElCliente.Provincia);
                cmd.Parameters.AddWithValue("@Canton", string.IsNullOrEmpty(ElCliente.Canton) ? (object)DBNull.Value : ElCliente.Canton);
                cmd.Parameters.AddWithValue("@Distrito", string.IsNullOrEmpty(ElCliente.Distrito) ? (object)DBNull.Value : ElCliente.Distrito);
                cmd.Parameters.AddWithValue("@Direccion", ElCliente.Direccion);
                cmd.Parameters.AddWithValue("@IdEstado", ElCliente.IdEstado);

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
