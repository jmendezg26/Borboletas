using Borboletas.Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Borboletas.AccesoDatos
{
    public class ClientesAD
    {
        private readonly BDConexion _BDConnection = new BDConexion();

        #region Carga de Datos
        private Clientes CargaClientes(IDataReader Ready)
        {
            return new Clientes
            {
                IdCliente = Convert.ToInt32(Ready["IdCliente"]),
                Nombre = Convert.ToString(Ready["Nombre"]),
                Cedula = Convert.ToString(Ready["Cedula"]),
                Telefono = Convert.ToString(Ready["Telefono"]),
                TelefonoSecundario = Convert.ToString(Ready["TelefonoSecundario"]),
                Provincia = Convert.ToString(Ready["Provincia"]),
                Canton = Convert.ToString(Ready["Canton"]),
                Distrito = Convert.ToString(Ready["Distrito"]),
                Direccion = Convert.ToString(Ready["DireccionExacta"]),
                IdEstado = Convert.ToInt32(Ready["IdEstado"]),
                FechaNacimiento = Ready["FechaNacimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(Ready["FechaNacimiento"]),
                FechaRegistro = Convert.ToDateTime(Ready["FechaRegistro"]),
                Detalles = Convert.ToString(Ready["Detalles"]),

            };
        }
        #endregion Carga de Datos

        #region Metodos Obtener
        public List<Clientes> ObtenerClientes()
        {
            List<Clientes> ListaClientes = new List<Clientes>();

            try
            {
                using SqlConnection conexion = new SqlConnection(_BDConnection.BD_CONEXION);

                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_ObtenerClientes";

                SqlDataReader DsReader = cmd.ExecuteReader();

                while (DsReader.Read())
                {
                    ListaClientes.Add(CargaClientes(DsReader));
                }

                conexion.Close();

                return ListaClientes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Clientes> ObtenerTodosLosClientes()
        {
            List<Clientes> ListaClientes = new List<Clientes>();

            try
            {
                using SqlConnection conexion = new SqlConnection(_BDConnection.BD_CONEXION);

                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_ObtenerClientesEstados";

                SqlDataReader DsReader = cmd.ExecuteReader();

                while (DsReader.Read())
                {
                    ListaClientes.Add(CargaClientes(DsReader));
                }

                conexion.Close();

                return ListaClientes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion Metodos Obtener

        #region Metodos Crear/Insertar
        public int AgregarCliente(NuevoCliente ElCliente)
        {
            int Resultado = 0;

            if (ElCliente.FechaNacimiento == DateTime.MinValue)
            {
                ElCliente.FechaNacimiento = null;
            }

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
                cmd.Parameters.AddWithValue("@FechaNacimiento", ElCliente.FechaNacimiento ?? (object)DBNull.Value);

                cmd.Parameters.AddWithValue("@Informacion", string.IsNullOrEmpty(ElCliente.Detalles) ? (object)DBNull.Value : ElCliente.Detalles);


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
                cmd.Parameters.AddWithValue("@FechaNacimiento",
                    ElCliente.FechaNacimiento == null || ElCliente.FechaNacimiento == DateTime.MinValue
                    ? (object)DBNull.Value
                    : ElCliente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Informacion", string.IsNullOrEmpty(ElCliente.Detalles) ? (object)DBNull.Value : ElCliente.Detalles);

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
