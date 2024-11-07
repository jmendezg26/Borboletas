﻿using Borboletas.Entidades;
using Borboletas.LogicaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Borboletas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : Controller
    {
        private readonly UsuariosLN _UsuarioLN = new UsuariosLN();

        #region Metodos Obtener

        [HttpPost("IniciarSesion")]
        public async Task<IActionResult> IniciarSesion([FromBody] InicioSesion Login)
        {
            UsuarioLogin ElUsuario = new UsuarioLogin();

            try
            {
                ElUsuario = _UsuarioLN.IniciarSesion(Login.Usuario, Login.Clave);

                if (ElUsuario.IdUsuario != 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = ElUsuario, success = true }));
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "Credenciales Incorrectas", success = false }));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = "Imposible ejecutar su transación", success = false });
            }
        }
        #endregion Metodos Obtener

        #region Metodos Crear/Insertar
        [HttpPost("CrearUsuario")]
        public async Task<IActionResult> CrearUsuario([FromBody] NuevoUsuario ElUsuarioNuevo)
        {
            int Resultado = 0;
            try
            {
                Resultado = _UsuarioLN.AgregarUsuario(ElUsuarioNuevo);

                if (Resultado != 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = ElUsuarioNuevo, success = true }));
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "No se pudo crear el usuario", success = false }));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = "Imposible ejecutar su transación", success = false });
            }
        }
        #endregion Metodos Crear/Insertar
    }
}
