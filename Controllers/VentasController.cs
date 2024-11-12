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
        private readonly VentasLN _VentasLN = new VentasLN();

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

        [HttpGet("ObtenerVentas")]
        public IActionResult ObtenerVentas()
        {
            List<ListarVentas> ListaDeVentas = new List<ListarVentas>();
            try
            {
                ListaDeVentas = _VentasLN.ObtenerVentas();

                if (ListaDeVentas.Count > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = ListaDeVentas, success = true }));
                }
                else if (ListaDeVentas.Count == 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "No hay ventas registradas", success = true }));
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "No se pudo obtener la lista de ventas", success = false }));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = "Imposible ejecutar su transación", success = false });
            }
        }
        #endregion Metodos Obtener

        #region Metodos Insertar
        [HttpPost("InsertarVenta")]
        public async Task<IActionResult> InsertarVenta([FromBody] NuevaVenta LaVenta)
        {
            int Venta = 0;
            int Abono = 0;
            try
            {
                Venta = _VentasLN.AgregarVenta(LaVenta);

                if (Venta != 0)
                {
                    if (LaVenta.AbonoInicial > 0)
                    {
                        NuevoAbono ElAbono = new NuevoAbono()
                        {
                            IdCuenta = Venta,
                            Abono = LaVenta.AbonoInicial,
                            SaldoAnterior = LaVenta.Total,
                            NuevoSaldo = LaVenta.Total - LaVenta.AbonoInicial,
                            IdUsuario = LaVenta.IdUsuario,
                        };

                        Abono = _VentasLN.AgregarAbono(ElAbono);

                        if (Abono != 0)
                        {
                            return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = LaVenta, success = true }));

                        }
                        else
                        {
                            return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "Se agrego la venta, pero no el abono inicial", success = false }));
                        }
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = LaVenta, success = true }));
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "No se pudo crear la venta", success = false }));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = "Imposible ejecutar su transación", success = false });
            }
        }

        [HttpPost("InsertarAbono")]
        public async Task<IActionResult> InsertarAbono([FromBody] NuevoAbono ElAbono)
        {
            int Resultado = 0;

            try
            {
                Resultado = _VentasLN.AgregarAbono(ElAbono);

                if (Resultado != 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = ElAbono, success = true }));
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "No se pudo insertar el abono", success = false }));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = "Imposible ejecutar su transación", success = false });
            }
        }
        #endregion Metodos Insertar
    }
}
