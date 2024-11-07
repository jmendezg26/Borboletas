using Borboletas.Entidades;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Borboletas.AccesoDatos
{
    public class UsuariosAD
    {
        private readonly BDConexion _BDConnection = new BDConexion();

        #region Metodos Obtener
        public UsuarioLogin IniciarSesion(string Usuario, string Clave)
        {
            UsuarioLogin ElUsuario = new UsuarioLogin();

            try
            {
                using SqlConnection conexion = new SqlConnection(_BDConnection.BD_CONEXION);

                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_IniciarSesion";
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Clave", Clave);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    ElUsuario.IdUsuario = int.Parse(reader[0].ToString());
                    ElUsuario.IdRol = int.Parse(reader[1].ToString());
                    ElUsuario.NombreUsuario = reader[2].ToString();
                    ElUsuario.Usuario = reader[3].ToString();
                    ElUsuario.Telefono = reader[4].ToString();
                    ElUsuario.Cedula = reader[5].ToString();
                    ElUsuario.IdEstado = int.Parse(reader[6].ToString());
                }

                return ElUsuario;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion Metodos Obtener
    }
}
