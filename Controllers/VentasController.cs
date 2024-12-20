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

        [HttpGet("HistorialAbonosXIdClienteIdCuenta")]
        public IActionResult HistorialAbonosXIdClienteIdCuenta(int IdCliente, int IdCuenta)
        {
            List<HistorialAbonosXIdCliente> HistorialAbonos = new List<HistorialAbonosXIdCliente>();
            try
            {
                HistorialAbonos = _VentasLN.HistorialAbonosXIdClienteIdCuenta(IdCliente, IdCuenta);

                if (HistorialAbonos.Count > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = HistorialAbonos, success = true }));
                }
                else if (HistorialAbonos.Count == 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "No hay abonos registrados", success = false }));
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "No se pudo obtener el historial de abonos", success = false }));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = "Imposible ejecutar su transación", success = false });
            }
        }

        [HttpGet("HistorialComprasXIdCliente")]
        public IActionResult HistorialComprasXIdCliente(int IdCliente)
        {
            List<HistorialComprasXIdCliente> HistorialCompras = new List<HistorialComprasXIdCliente>();
            try
            {
                HistorialCompras = _VentasLN.HistorialComprasXIdCliente(IdCliente);

                if (HistorialCompras.Count > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = HistorialCompras, success = true }));
                }
                else if (HistorialCompras.Count == 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "No hay abonos registrados", success = false }));
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "No se pudo obtener el historial de abonos", success = false }));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = "Imposible ejecutar su transación", success = false });
            }
        }

        [HttpGet("HistorialComprasGeneral")]
        public IActionResult HistorialComprasGeneral()
        {
            List<HistorialComprasGeneral> HistorialCompras = new List<HistorialComprasGeneral>();
            try
            {
                HistorialCompras = _VentasLN.HistorialComprasGeneral();

                if (HistorialCompras.Count > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = HistorialCompras, success = true }));
                }
                else if (HistorialCompras.Count == 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "No hay abonos registrados", success = false }));
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "No se pudo obtener el historial de abonos", success = false }));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = "Imposible ejecutar su transación", success = false });
            }
        }

        [HttpGet("HistorialComprasTiendas")]
        public IActionResult HistorialComprasTiendas()
        {
            List<HistorialComprasTiendas> HistorialCompras = new List<HistorialComprasTiendas>();
            try
            {
                HistorialCompras = _VentasLN.ObtenerHistorialComprasTiendas();

                if (HistorialCompras.Count > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = HistorialCompras, success = true }));
                }
                else if (HistorialCompras.Count == 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "No hay compras registradas", success = false }));
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "No se pudo obtener el historial de abonos", success = false }));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = "Imposible ejecutar su transación", success = false });
            }
        }


        [HttpGet("ObtenerDetallesVenta")]
        public IActionResult ObtenerDetallesVenta(int IdVenta)
        {
            List<DetalleVenta> DetallesVenta = new List<DetalleVenta>();
            try
            {
                DetallesVenta = _VentasLN.DetallesDeVenta(IdVenta);

                if (DetallesVenta.Count > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = DetallesVenta, success = true }));
                }
                else if (DetallesVenta.Count == 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "No hay compras registradas", success = false }));
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "No se pudo obtener el historial de abonos", success = false }));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = "Imposible ejecutar su transación", success = false });
            }
        }

        [HttpGet("ObtenerCuentasXCobrar")]
        public IActionResult HistorialCuentasXCobrar()
        {
            List<HistorialCuentasXCobrar> CuentasXCobrar = new List<HistorialCuentasXCobrar>();
            try
            {
                CuentasXCobrar = _VentasLN.HistorialCuentasXCobrar();

                if (CuentasXCobrar.Count > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = CuentasXCobrar, success = true }));
                }
                else if (CuentasXCobrar.Count == 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "No hay compras registradas", success = false }));
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "No se pudo obtener el historial de abonos", success = false }));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = "Imposible ejecutar su transación", success = false });
            }
        }

        [HttpGet("ObtenerTopVentas")]
        public IActionResult ObtenerTopVentas(string Anno)
        {
            List<TopVentas> TopVentas = new List<TopVentas>();

            try
            {
                TopVentas = _VentasLN.ObtenerTopVentas(Anno);

                if (TopVentas.Count > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = TopVentas, success = true }));
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "No se pudo obtener el historial de abonos", success = false }));
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
            int CuentaXCobrar = 0;
            int Abono = 0;

            try
            {
                Venta = _VentasLN.AgregarVenta(LaVenta);

                if (Venta != 0)
                {
                    foreach (var item in LaVenta.ListaArticulo)
                    {
                        ArticulosDeVenta ElProducto = new ArticulosDeVenta()
                        {
                            IdVenta = Venta,
                            Articulo = item.Articulo,
                            IdTienda = item.IdTienda,
                            Peso = item.Peso,
                            Precio = item.Precio,
                            Cantidad = item.Cantidad
                        };

                        InsertarProductos(ElProducto);
                    }

                    if (LaVenta.IdTipoVenta == 2)
                    {
                        NuevaCuentaXCobrar LaCuentaXCobrar = new NuevaCuentaXCobrar();
                        LaCuentaXCobrar.IdVenta = Venta;

                        if (LaVenta.AbonoInicial != 0 && LaVenta.AbonoInicial != null)
                        {
                            LaCuentaXCobrar.SaldoPendiente = LaVenta.Total - LaVenta.AbonoInicial;
                        }
                        else
                        {
                            LaCuentaXCobrar.SaldoPendiente = LaVenta.Total;
                        }

                        CuentaXCobrar = InsertarCuentaXCobrar(LaCuentaXCobrar);

                        if (CuentaXCobrar != 0)
                        {
                            if (LaVenta.AbonoInicial > 0)
                            {
                                NuevoAbono ElAbono = new NuevoAbono()
                                {
                                    IdCuenta = CuentaXCobrar,
                                    Abono = LaVenta.AbonoInicial,
                                    SaldoAnterior = LaVenta.Total,
                                    NuevoSaldo = LaVenta.Total - LaVenta.AbonoInicial,
                                    IdUsuario = LaVenta.IdUsuario,
                                };

                                Abono = InsertarAbonoInicial(ElAbono);

                                if (Abono != 0)
                                {
                                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = LaVenta, success = true }));

                                }
                                else
                                {
                                    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "Se agrego la venta y la cuenta por cobrar, pero no el abono inicial", success = false }));
                                }
                            }
                            else
                            {
                                return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = LaVenta, success = true }));
                            }
                        }
                        else
                        {
                            return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "Se agrego la venta, pero no se creo la cuenta por cobrar", success = false }));
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

        public int InsertarCuentaXCobrar(NuevaCuentaXCobrar LaCuenta)
        {
            int Resultado = 0;

            try
            {
                Resultado = _VentasLN.AgregarCuentaXCobrar(LaCuenta);

                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int InsertarAbonoInicial(NuevoAbono ElAbono)
        {
            int Resultado = 0;

            try
            {
                Resultado = _VentasLN.AgregarAbono(ElAbono);

                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpPost("InsertarAbono")]
        public async Task<IActionResult> InsertarAbono([FromBody] NuevoAbono ElAbono)
        {
            int Abono = 0;
            int CuentaXCobrar = 0;

            try
            {
                Abono = _VentasLN.AgregarAbono(ElAbono);

                if (Abono != 0)
                {
                    EditarCuentaXCobrar LaCuenta = new EditarCuentaXCobrar();
                    LaCuenta.IdCuenta = ElAbono.IdCuenta;
                    LaCuenta.NuevoSaldo = ElAbono.SaldoAnterior - ElAbono.Abono;
                    if (LaCuenta.NuevoSaldo > 0)
                    {
                        LaCuenta.IdEstado = 3;
                    }
                    else
                    {
                        LaCuenta.IdEstado = 4;
                    }

                    CuentaXCobrar = EditarCuentaXCobrar(LaCuenta);

                    if (CuentaXCobrar != 0)
                    {
                        return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = ElAbono, success = true }));
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "Se agrego el abono, pero no se pudo actualizar la CxC", success = false }));
                    }
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

        public void InsertarProductos(ArticulosDeVenta ElProducto)
        {
            try
            {
                _VentasLN.InsertarArticuloVenta(ElProducto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        #endregion Metodos Insertar

        #region Metodos Editar
        public int EditarCuentaXCobrar(EditarCuentaXCobrar LaCuenta)
        {
            int Resultado = 0;

            try
            {
                return Resultado = _VentasLN.EditarCuentaXCobrar(LaCuenta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion Metodos Editar
    }
}
