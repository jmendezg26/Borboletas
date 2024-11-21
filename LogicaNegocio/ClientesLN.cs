using Borboletas.AccesoDatos;
using Borboletas.Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Borboletas.LogicaNegocio
{
    public class ClientesLN
    {
        private readonly ClientesAD _ClientesAD = new ClientesAD();

        #region Metodos Obtener
        public List<Clientes> ObtenerClientes()
        {
            List<Clientes> ListaClientes = new List<Clientes>();

            try
            {
                return ListaClientes = _ClientesAD.ObtenerClientes();
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
                return ListaClientes = _ClientesAD.ObtenerTodosLosClientes();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion Metodos Obtener

        #region Metodos Insertar/Crear
        public int AgregarCliente(NuevoCliente ElCliente)
        {
            int Resultado = 0;

            try
            {
                Resultado = _ClientesAD.AgregarCliente(ElCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Resultado;
        }
        #endregion Metodos Insertar/Crear

        #region Metodos Editar
        public int EditarCliente(EditarCliente ElCliente)
        {
            int Resultado = 0;

            try
            {
                Resultado = _ClientesAD.EditarCliente(ElCliente);
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
