using Borboletas.AccesoDatos;
using Borboletas.Entidades;

namespace Borboletas.LogicaNegocio
{
    public class ClientesLN
    {
        private readonly ClientesAD _ClientesAD = new ClientesAD();


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
