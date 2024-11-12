using Borboletas.Entidades;
using System.Data;
using System.Data.SqlClient;

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
                FechaCancelacion = Convert.ToDateTime(Ready["FechaCancelacion"]),
                PesoTotal = Convert.ToDouble(Ready["PesoTotal"]),
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
        #endregion Metodos Obtener

        #region Metodos Insertar
        public int AgregarVenta(NuevaVenta LaVenta)
        {
            int Venta = 0;

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
                cmd.Parameters.AddWithValue("@FechaCancelacion", LaVenta.FechaCancelacion);
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
                cmd.Parameters.AddWithValue("@IdCliente", ElAbono.IdCuenta);
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
        #endregion Metodos Insertar
    }
}
