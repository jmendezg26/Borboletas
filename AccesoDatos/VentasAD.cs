using Borboletas.Entidades;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Borboletas.AccesoDatos
{
    public class VentasAD
    {
        private readonly BDConexion _BDConnection = new BDConexion();

        #region Metodos Carga de Datos
        private ListarVentas CargaListaVentas(IDataReader Ready)
        {
            return new ListarVentas
            {
                IdVenta = Convert.ToInt32(Ready["IdVenta"]),
                IdCliente = Convert.ToInt32(Ready["IdCliente"]),
                NombreCliente = Convert.ToString(Ready["Cliente"]),
                IdTipoVenta = Convert.ToInt32(Ready["IdTipoVenta"]),
                TipoVenta = Convert.ToString(Ready["TipoVenta"]),
                Informacion = Convert.ToString(Ready["Informacion"]),
                Total = Convert.ToDouble(Ready["Total"]),
                IdEstado = Convert.ToInt32(Ready["IdEstado"]),
                Estado = Convert.ToString(Ready["Estado"]),
                FechaVenta = Convert.ToDateTime(Ready["FechaVenta"]),
                IdUsuario = Convert.ToInt32(Ready["IdUsuario"]),
                Vendedor = Convert.ToString(Ready["Vendedor"]),
                TipoMoneda = Convert.ToInt32(Ready["TipoMoneda"]),
                FechaCancelacion = Ready["FechaCancelacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(Ready["FechaCancelacion"]),
                PesoTotal = Convert.ToDouble(Ready["PesoTotal"]),
            };
        }

        private HistorialAbonosXIdCliente CargaHistorialAbonosXIdCliente(IDataReader Ready)
        {
            return new HistorialAbonosXIdCliente
            {
                IdCliente = Convert.ToInt32(Ready["IdCliente"]),
                IdCuenta = Convert.ToInt32(Ready["IdCuenta"]),
                SaldoPendiente = Convert.ToDouble(Ready["SaldoPendiente"]),
                MontoTotal = Convert.ToDouble(Ready["Total"]),
                Abono = Convert.ToDouble(Ready["Abono"]),
                FechaAbono = Convert.ToDateTime(Ready["FechaRegistro"]),
            };
        }

        private HistorialComprasXIdCliente CargaHistorialComprasXIdCliente(IDataReader Ready)
        {
            return new HistorialComprasXIdCliente
            {
                IdCliente = Convert.ToInt32(Ready["IdCliente"]),
                IdCuenta = Convert.ToInt32(Ready["IdCuenta"]),
                FechaVenta = Convert.ToDateTime(Ready["FechaVenta"]),
                Articulos = Convert.ToString(Ready["Articulos"]),
                MontoTotal = Convert.ToDouble(Ready["Total"]),
                SaldoPendiente = Convert.ToDouble(Ready["SaldoPendiente"]),
                FechaCancelacion = Ready["FechaCancelacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(Ready["FechaCancelacion"]),
                IdTipoVenta = Convert.ToInt32(Ready["IdTipoVenta"]),
                IdEstadoVenta = Convert.ToInt32(Ready["IdEstado"]),
                TipoMoneda = Convert.ToInt32(Ready["TipoMoneda"]),
            };
        }

        private HistorialComprasTiendas CargaHistorialComprasTiendas(IDataReader Ready)
        {
            return new HistorialComprasTiendas
            {
                FechaVenta = Convert.ToDateTime(Ready["FechaVenta"]),
                Tienda = Convert.ToString(Ready["Tienda"]),
                Articulo = Convert.ToString(Ready["Articulo"]),
                Cliente = Convert.ToString(Ready["Cliente"]),
            };
        }
        #endregion Metodos Carga de Datos

        #region Metodos Obtener
        public List<ListarVentas> ObtenerVentas()
        {
            List<ListarVentas> ListaDeVentas = new List<ListarVentas>();

            try
            {
                using SqlConnection conexion = new SqlConnection(_BDConnection.BD_CONEXION);

                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_ObtenerVentas";

                SqlDataReader DsReader = cmd.ExecuteReader();

                while (DsReader.Read())
                {
                    ListaDeVentas.Add(CargaListaVentas(DsReader));
                }

                conexion.Close();

                return ListaDeVentas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<HistorialAbonosXIdCliente> HistorialAbonosXIdClienteIdCuenta(int IdCliente, int IdCuenta)
        {
            List<HistorialAbonosXIdCliente> HistorialAbonos = new List<HistorialAbonosXIdCliente>();

            try
            {
                using SqlConnection conexion = new SqlConnection(_BDConnection.BD_CONEXION);

                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_ObtenerHistorialAbonosXIdCliente";
                cmd.Parameters.AddWithValue("@IdCliente", IdCliente);
                cmd.Parameters.AddWithValue("@IdCuenta", IdCuenta);

                SqlDataReader DsReader = cmd.ExecuteReader();

                while (DsReader.Read())
                {
                    HistorialAbonos.Add(CargaHistorialAbonosXIdCliente(DsReader));
                }

                conexion.Close();

                return HistorialAbonos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<HistorialComprasXIdCliente> HistorialComprasXIdCliente(int IdCliente)
        {
            List<HistorialComprasXIdCliente> HistorialCompras = new List<HistorialComprasXIdCliente>();

            try
            {
                using SqlConnection conexion = new SqlConnection(_BDConnection.BD_CONEXION);

                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_ObtenerHistorialComprasXIdCliente";
                cmd.Parameters.AddWithValue("@IdCliente", IdCliente);

                SqlDataReader DsReader = cmd.ExecuteReader();

                while (DsReader.Read())
                {
                    HistorialCompras.Add(CargaHistorialComprasXIdCliente(DsReader));
                }

                conexion.Close();

                return HistorialCompras;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<HistorialComprasTiendas> ObtenerHistorialComprasTiendas()
        {
            List<HistorialComprasTiendas> HistorialCompras = new List<HistorialComprasTiendas>();

            try
            {
                using SqlConnection conexion = new SqlConnection(_BDConnection.BD_CONEXION);

                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_ObtenerTiendasCompras";

                SqlDataReader DsReader = cmd.ExecuteReader();

                while (DsReader.Read())
                {
                    HistorialCompras.Add(CargaHistorialComprasTiendas(DsReader));
                }

                conexion.Close();

                return HistorialCompras;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion Metodos Obtener

        #region Metodos Insertar
        public int AgregarVenta(NuevaVenta LaVenta)
        {
            int Venta = 0;

            if (LaVenta.FechaCancelacion == DateTime.MinValue)
            {
                LaVenta.FechaCancelacion = null;
            }

            try
            {
                using SqlConnection conexion = new SqlConnection(_BDConnection.BD_CONEXION);

                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_InsertarVenta";
                cmd.Parameters.AddWithValue("@IdCliente", LaVenta.IdCliente);
                cmd.Parameters.AddWithValue("@IdTipoVenta", LaVenta.IdTipoVenta);
                cmd.Parameters.AddWithValue("@Informacion", string.IsNullOrEmpty(LaVenta.Informacion) ? (object)DBNull.Value : LaVenta.Informacion);
                cmd.Parameters.AddWithValue("@Total", LaVenta.Total);
                cmd.Parameters.AddWithValue("@IdEstado", LaVenta.IdEstado);
                cmd.Parameters.AddWithValue("@FechaVenta", LaVenta.FechaVenta);
                cmd.Parameters.AddWithValue("@IdUsuario", LaVenta.IdUsuario);
                cmd.Parameters.AddWithValue("@TipoMoneda", LaVenta.TipoMoneda);
                cmd.Parameters.AddWithValue("@FechaCancelacion", LaVenta.FechaCancelacion ?? (object)DBNull.Value);

                cmd.Parameters.AddWithValue("@PesoTotal", LaVenta.PesoTotal);


                cmd.Parameters.Add("@ID", SqlDbType.BigInt);
                cmd.Parameters["@ID"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                Venta = Convert.ToInt32(cmd.Parameters["@ID"].Value);

                conexion.Close();
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Venta;
        }

        public int AgregarAbono(NuevoAbono ElAbono)
        {
            int Resultado = 0;

            try
            {
                using SqlConnection conexion = new SqlConnection(_BDConnection.BD_CONEXION);

                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_InsertarAbono";
                cmd.Parameters.AddWithValue("@IdCuenta", ElAbono.IdCuenta);
                cmd.Parameters.AddWithValue("@Abono", ElAbono.Abono);
                cmd.Parameters.AddWithValue("@SaldoAnterior", ElAbono.SaldoAnterior);
                cmd.Parameters.AddWithValue("@NuevoSaldo", ElAbono.NuevoSaldo);
                cmd.Parameters.AddWithValue("@IdUsuario", ElAbono.IdUsuario);

                cmd.Parameters.Add("@ID", SqlDbType.BigInt);
                cmd.Parameters["@ID"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                Resultado = Convert.ToInt32(cmd.Parameters["@ID"].Value);

                conexion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Resultado;
        }

        public int AgregarCuentaXCobrar(NuevaCuentaXCobrar LaCuenta)
        {
            int Resultado = 0;

            try
            {
                using SqlConnection conexion = new SqlConnection(_BDConnection.BD_CONEXION);

                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_InsertarCuentaXCobrar";
                cmd.Parameters.AddWithValue("@IdVenta", LaCuenta.IdVenta);
                cmd.Parameters.AddWithValue("@SaldoPendiente", LaCuenta.SaldoPendiente);


                cmd.Parameters.Add("@ID", SqlDbType.BigInt);
                cmd.Parameters["@ID"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                Resultado = Convert.ToInt32(cmd.Parameters["@ID"].Value);

                conexion.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Resultado;
        }
        #endregion Metodos Insertar

        #region Metodos Editar
        public int EditarCuentaXCobrar(EditarCuentaXCobrar LaCuenta)
        {
            int Resultado = 0;

            try
            {
                using SqlConnection conexion = new SqlConnection(_BDConnection.BD_CONEXION);

                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PA_ModificarCuentaXCobrar";
                cmd.Parameters.AddWithValue("@IdCuenta", LaCuenta.IdCuenta);
                cmd.Parameters.AddWithValue("@SaldoPendiente", LaCuenta.NuevoSaldo);
                cmd.Parameters.AddWithValue("@IdEstado", LaCuenta.IdEstado);

                cmd.Parameters.Add("@Resultado", SqlDbType.BigInt);
                cmd.Parameters["@Resultado"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                Resultado = Convert.ToInt32(cmd.Parameters["@Resultado"].Value);

                conexion.Close();
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
