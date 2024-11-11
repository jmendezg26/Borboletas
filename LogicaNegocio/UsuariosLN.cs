using Borboletas.AccesoDatos;
using Borboletas.Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Borboletas.LogicaNegocio
{
    public class UsuariosLN
    {
        private readonly UsuariosAD _UsuarioAD = new UsuariosAD();

        #region Metodos Obtener
        public UsuarioLogin IniciarSesion(string Usuario, string Clave)
        {
            UsuarioLogin ElUsuario = new UsuarioLogin();

            try
            {
                ElUsuario = _UsuarioAD.IniciarSesion(Usuario, Clave);

                return ElUsuario;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al obtener el usuario", ex);
            }
        }

        public List<Usuarios> ObtenerUsuarios()
        {
            List<Usuarios> ListaUsuarios = new List<Usuarios>();

            try
            {
                return ListaUsuarios = _UsuarioAD.ObtenerUsuarios();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion Metodos Obtener

        #region Metodos Crear/Insertar
        public int AgregarUsuario(NuevoUsuario ElUsuario)
        {
            int Resultado = 0;

            try
            {
                Resultado = _UsuarioAD.AgregarUsuario(ElUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Resultado;
        }
        #endregion Metodos Crear/Insertar

        #region Metodos Actualizar
        public int EditarUsuario(EditarUsuario ElUsuario)
        {
            int Resultado = 0;

            try
            {
               Resultado = _UsuarioAD.EditarUsuario(ElUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Resultado;
        }
        #endregion Metodos Actualizar

    }
}
