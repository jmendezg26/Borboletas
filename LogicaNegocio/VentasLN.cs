﻿using Borboletas.AccesoDatos;
using Borboletas.Entidades;

namespace Borboletas.LogicaNegocio
{
    public class VentasLN
    {
        private readonly VentasAD _VentasAD = new VentasAD();

        #region Metodos Obtener
        public List<ListarVentas> ObtenerVentas()
        {
            List<ListarVentas> ListaDeVentas = new List<ListarVentas>();

            try
            {
                return ListaDeVentas = _VentasAD.ObtenerVentas();
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
                return HistorialAbonos = _VentasAD.HistorialAbonosXIdClienteIdCuenta(IdCliente, IdCuenta);
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
                return HistorialCompras = _VentasAD.HistorialComprasXIdCliente(IdCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<HistorialComprasGeneral> HistorialComprasGeneral()
        {
            List<HistorialComprasGeneral> HistorialCompras = new List<HistorialComprasGeneral>();

            try
            {
                return HistorialCompras = _VentasAD.HistorialComprasGeneral();
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
                return HistorialCompras = _VentasAD.ObtenerHistorialComprasTiendas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<DetalleVenta> DetallesDeVenta(int IdVenta)
        {
            List<DetalleVenta> DetallesVenta = new List<DetalleVenta>();

            try
            {
                return DetallesVenta = _VentasAD.DetallesDeVenta(IdVenta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<HistorialCuentasXCobrar> HistorialCuentasXCobrar()
        {
            List<HistorialCuentasXCobrar> CuentasXCobrar = new List<HistorialCuentasXCobrar>();

            try
            {
                return CuentasXCobrar = _VentasAD.HistorialCuentasXCobrar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<TopVentas> ObtenerTopVentas(string Anno)
        {
            List<TopVentas> TopVentas = new List<TopVentas>();

            try
            {
                return TopVentas = _VentasAD.ObtenerTopVentas(Anno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<HistorialNotasCxC> ObtenerNotasCxC(int IdCuentaCxC)
        {
            List<HistorialNotasCxC> NotasCxC = new List<HistorialNotasCxC>();

            try
            {
                return NotasCxC = _VentasAD.ObtenerNotasCxC(IdCuentaCxC);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public double ObtenerTipoCambio()
        {
            double TipoCambio = 0;

            try
            {
                TipoCambio = _VentasAD.ObtenerTipoCambio();

                return TipoCambio;
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
                Venta = _VentasAD.AgregarVenta(LaVenta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Venta;
        }

        public int AgregarAbono(NuevoAbono ElAbono)
        {
            int Abono = 0;

            try
            {
                Abono = _VentasAD.AgregarAbono(ElAbono);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Abono;
        }

        public int AgregarCuentaXCobrar(NuevaCuentaXCobrar LaCuenta)
        {
            int Abono = 0;

            try
            {
                Abono = _VentasAD.AgregarCuentaXCobrar(LaCuenta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Abono;
        }

        public void InsertarArticuloVenta(ArticulosDeVenta ElProducto)
        {
            try
            {
                _VentasAD.InsertarArticuloVenta(ElProducto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int AgregarNota(NuevaNota LaNota)
        {
            int Nota = 0;

            try
            {
                Nota = _VentasAD.AgregarNota(LaNota);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Nota;
        }


        public double AgregarTipoCambio(double TipoDeCambio)
        {
            double TipoCambio = 0;

            try
            {
                TipoCambio = _VentasAD.AgregarTipoCambio(TipoDeCambio);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return TipoCambio;
        }
        #endregion Metodos Insertar

        #region Metodos Editar
        public int EditarCuentaXCobrar(EditarCuentaXCobrar LaCuenta)
        {
            int Resultado = 0;

            try
            {
                Resultado = _VentasAD.EditarCuentaXCobrar(LaCuenta);
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
