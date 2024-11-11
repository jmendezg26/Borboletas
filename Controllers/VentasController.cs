using Borboletas.Entidades;
using Borboletas.LogicaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Borboletas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentasController : Controller
    {
        private readonly TiendasLN _TiendasLN = new TiendasLN();

        #region Metodos Obtener

        [HttpGet("ObtenerTiendas")]
        public IActionResult ObtenerTiendas()
        {
            List<Tiendas> ListaTiendas = new List<Tiendas>();
            try
            {
                ListaTiendas = _TiendasLN.ObtenerTiendas();

                if (ListaTiendas.Count > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = ListaTiendas, success = true }));
                }
                else if (ListaTiendas.Count == 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "No hay tiendas registrados", success = true }));
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
    }
}
