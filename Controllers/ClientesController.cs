using Borboletas.Entidades;
using Borboletas.LogicaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Borboletas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : Controller
    {
        private readonly ClientesLN _ClientesLN = new ClientesLN();

        #region Metodos Crear/Insertar

        [HttpPost("CrearCliente")]
        public async Task<IActionResult> CrearCliente([FromBody] NuevoCliente ElCliente)
        {
            int Resultado = 0;
            try
            {
                Resultado = _ClientesLN.AgregarCliente(ElCliente);

                if (Resultado != 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = ElCliente, success = true }));
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

        #region Metodos Editar

        [HttpPost("EditarCliente")]
        public async Task<IActionResult> EditarCliente([FromBody] EditarCliente ElCliente)
        {
            int Resultado = 0;

            try
            {
                Resultado = _ClientesLN.EditarCliente(ElCliente);

                if (Resultado != 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = ElCliente, success = true }));
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "No se pudo modificar el cliente", success = false }));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = "Imposible ejecutar su transación", success = false });
            }
        }
        #endregion Metodos Editar
    }
}
