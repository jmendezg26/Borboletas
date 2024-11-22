using Borboletas.Entidades;
using Borboletas.LogicaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Borboletas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogosController : Controller
    {
        private readonly TiendasLN _TiendasLN = new TiendasLN();
        private readonly ArticulosPesosLN _ArticulosPesosLN = new ArticulosPesosLN();

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

        [HttpGet("ObtenerTiendasEstados")]
        public IActionResult ObtenerTiendasEstados()
        {
            List<Tiendas> ListaTiendas = new List<Tiendas>();
            try
            {
                ListaTiendas = _TiendasLN.ObtenerTiendasEstados();

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

        [HttpGet("ObtenerCatalogoArticulos")]
        public IActionResult ObtenerCatalogoArticulos()
        {
            List<ArticulosPesos> ListaArticulos = new List<ArticulosPesos>();
            try
            {
                ListaArticulos = _ArticulosPesosLN.ObtenerCatalogoArticulos();

                if (ListaArticulos.Count > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = ListaArticulos, success = true }));
                }
                else if (ListaArticulos.Count == 0)
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

        #region Metodos Insertar
        [HttpPost("CrearTienda")]
        public async Task<IActionResult> CrearTienda([FromBody] Tiendas LaTienda)
        {
            int Resultado = 0;
            try
            {
                Resultado = _TiendasLN.AgregarTienda(LaTienda);

                if (Resultado != 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = LaTienda, success = true }));
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "No se pudo crear la tienda", success = false }));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = "Imposible ejecutar su transación", success = false });
            }
        }

        [HttpPost("AgregarArticuloCatalogo")]
        public async Task<IActionResult> AgregarArticuloCatalogo([FromBody] ArticulosPesos ElArticulo)
        {
            int Resultado = 0;
            try
            {
                Resultado = _ArticulosPesosLN.AgregarArticuloCatalogo(ElArticulo);

                if (Resultado != 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = ElArticulo, success = true }));
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "No se pudo crear el articulo", success = false }));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = "Imposible ejecutar su transación", success = false });
            }
        }
        #endregion Metodos Insertar

        #region Metodos Editar
        [HttpPost("EditarTienda")]
        public async Task<IActionResult> EditarTienda([FromBody] Tiendas LaTienda)
        {
            int Resultado = 0;
            try
            {
                Resultado = _TiendasLN.EditarTienda(LaTienda);

                if (Resultado != 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = Resultado, success = true }));
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "No se pudo editar la tienda", success = false }));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = "Imposible ejecutar su transación", success = false });
            }
        }

        [HttpPost("EditarArticuloCatalogo")]
        public async Task<IActionResult> EditarArticuloCatalogo([FromBody] ArticulosPesos ElArticulo)
        {
            int Resultado = 0;
            try
            {
                Resultado = _ArticulosPesosLN.EditarArticulo(ElArticulo);

                if (Resultado != 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = Resultado, success = true }));
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "No se pudo editar la tienda", success = false }));
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
