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

        #region Metodos Obtener
        [HttpGet("ObtenerClientes")] //Activos
        public IActionResult ObtenerClientes()
        {
            List<Clientes> ListaClientes = new List<Clientes>();
            try
            {
                ListaClientes = _ClientesLN.ObtenerClientes();

                if (ListaClientes.Count > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = ListaClientes, success = true }));
                }
                else if (ListaClientes.Count == 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "No hay clientes registrados", success = true }));
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "No se pudo obtener la lista de clientes", success = false }));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = "Imposible ejecutar su transación", success = false });
            }
        }

        [HttpGet("ObtenerTodosLosClientes")] //Activos e Inactivos
        public IActionResult ObtenerTodosLosClientes()
        {
            List<Clientes> ListaClientes = new List<Clientes>();
            try
            {
                ListaClientes = _ClientesLN.ObtenerTodosLosClientes();

                if (ListaClientes.Count > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = ListaClientes, success = true }));
                }
                else if (ListaClientes.Count == 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "No hay clientes registrados", success = true }));
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "No se pudo obtener la lista de clientes", success = false }));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = "Imposible ejecutar su transación", success = false });
            }
        }
        #endregion Metodos Obtener

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
