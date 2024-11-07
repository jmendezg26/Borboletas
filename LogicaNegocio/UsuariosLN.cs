﻿using Borboletas.AccesoDatos;
using Borboletas.Entidades;

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
    }
}
