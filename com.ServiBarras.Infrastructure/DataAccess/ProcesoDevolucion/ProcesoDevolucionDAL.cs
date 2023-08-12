using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.LogEvent;
using com.ServiBarras.Shared.ModelDTO;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class ProcesoDevolucionDAL : IProcesoDevolucionDAL
    {
        public TecnoCEDI_bdContext dbcontext;
        /// <summary>
        /// Constructor, genera una instancia del contexto de la base de datos
        /// </summary>
        public ProcesoDevolucionDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }

        public DataSet GetValidarProcesoDevolucionCargaUsuario(long usuarioId)
        {          
            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_ValidarProcesoDevolucionCargaUsuario]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@usuarioId", usuarioId);                      
                        command.CommandTimeout = 0;
                        var adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataSet);
                    }
                    return dataSet;
                }
                catch (System.Exception ex)
                {
                    LogEvent log = new LogEvent();
                    log.LogWrite(ex.Message);
                    return null;
                }
                finally
                {
                    connection.Close();
                }

            }
        }


        public DataSet SPProcesoDevolucion(ProcesoDevolucionDTO devolucionAux)
        {
            if (devolucionAux == null) return null;
            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_SET_ProcesarDevolucion]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;                       
                        command.Parameters.AddWithValue("@contenedorId", devolucionAux.contenedorId);
                        command.Parameters.AddWithValue("@consecutivoEstiba", devolucionAux.estibaConsecutivo);
                        command.Parameters.AddWithValue("@ubicacionIdOrigen", devolucionAux.ubicacionId);
                        command.Parameters.AddWithValue("@novedadId", devolucionAux.novedadId);
                        command.Parameters.AddWithValue("@usuarioId", devolucionAux.usuarioId);
                        command.Parameters.AddWithValue("@accion", devolucionAux.accion);
                        command.Parameters.AddWithValue("@pedidoId", devolucionAux.pedidoId);
                        command.Parameters.AddWithValue("@devolucionProcesoId", devolucionAux.devolucionProcesoId);
                        command.Parameters.AddWithValue("@proceso", devolucionAux.proceso);

                        command.CommandTimeout = 0;
                        var adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataSet);
                    }
                    return dataSet;
                }
                catch (System.Exception ex)
                {
                    LogEvent log = new LogEvent();
                    log.LogWrite(ex.Message);
                    return null;
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        public DataSet SetProcesarDevolucionTransaccion(DevolucionTransaccionDTO devolucionAux)
        {

            if (devolucionAux == null) return null;
            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("SP_SET_ProcesarDevolucionTransaccion", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UsuarioId", devolucionAux.usuarioId);
                        command.Parameters.AddWithValue("@UbicacionIdOrigen", devolucionAux.ubicacionIdOrigen);
                        command.Parameters.AddWithValue("@ContenedorId", devolucionAux.contenedorId);
                        command.Parameters.AddWithValue("@PedidoId", (devolucionAux.pedidoId == null) ? 0 : devolucionAux.pedidoId);
                        command.Parameters.AddWithValue("@ruteoId", devolucionAux.ruteoId);
                        command.Parameters.AddWithValue("@PuertaId", devolucionAux.puertaId);                       
                        command.CommandTimeout = 0;
                        var adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataSet);
                    }
                    return dataSet;
                }
                catch (System.Exception ex)
                {
                    LogEvent log = new LogEvent();
                    log.LogWrite(ex.Message);
                    return null;
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        public DataSet ValidarDespachoCargaUsuarioDevolucion(long usuarioId)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_ValidarDespachoCargaUsuarioDevolucion]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@usuarioId", usuarioId);
                        command.CommandTimeout = 0;
                        var adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataSet);
                    }
                    return dataSet;
                }
                catch (System.Exception ex)
                {
                    LogEvent log = new LogEvent();
                    log.LogWrite(ex.Message);
                    return null;
                }

                finally
                {
                    connection.Close();
                }
            }
        }


        public DataSet GetContenedoresByContenedorCodigoDevolucion(DevolucionContenedoDTO devolucionAux)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_ContenedoresByContenedorCodigoDevolucion]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ContenedorCodigo", devolucionAux.contenedorCodigo);
                        command.Parameters.AddWithValue("@ubicacionId", devolucionAux.ubicacionId);
                        command.CommandTimeout = 0;
                        var adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataSet);
                    }
                    return dataSet;
                }
                catch (System.Exception ex)
                {
                    LogEvent log = new LogEvent();
                    log.LogWrite(ex.Message);
                    return null;
                }

                finally
                {
                    connection.Close();
                }
            }
        }

        public DataSet GetUbicacionesDespachoParcialDevolucion()
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_UbicacionesDespachoParcialDevolucion]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandTimeout = 0;
                        var adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataSet);
                    }
                    return dataSet;
                }
                catch (System.Exception ex)
                {
                    LogEvent log = new LogEvent();
                    log.LogWrite(ex.Message);
                    return null;
                }

                finally
                {
                    connection.Close();
                }
            }
        }

        public DataSet GetSaldoDetalleUbicacionContenedorCodigo(SaldoUbicacionContenedorDTO saldoAux)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_SaldoDetalleUbicacionContenedorCodigo]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ubicacionId", saldoAux.ubicacionId);
                        command.Parameters.AddWithValue("@contenedorCodigo", saldoAux.contenedorCodigo);
                        command.Parameters.AddWithValue("@estibaCompleta", saldoAux.estibaCompleta);
                        command.CommandTimeout = 0;
                        var adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataSet);
                    }
                    return dataSet;
                }
                catch (System.Exception ex)
                {
                    LogEvent log = new LogEvent();
                    log.LogWrite(ex.Message);
                    return null;
                }

                finally
                {
                    connection.Close();
                }
            }
        }

        public DataSet GetDevolucionDespacho()
        {
            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_Devolucion]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;                       
                        command.CommandTimeout = 0;
                        var adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataSet);
                    }
                    return dataSet;
                }
                catch (System.Exception ex)
                {
                    LogEvent log = new LogEvent();
                    log.LogWrite(ex.Message);
                    return null;
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        public DataSet SetComprometerSaldoDevolucion(SaldoDevolucionDTO saldoCompromiso)
        {
            if (saldoCompromiso == null) return null;
            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_SET_ComprometerDevolucion]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@devolucionId", saldoCompromiso.devolucionId);
                        command.Parameters.AddWithValue("@usuarioId", saldoCompromiso.usuarioId);
                        command.CommandTimeout = 0;
                        var adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataSet);
                    }
                    return dataSet;
                }
                catch (System.Exception ex)
                {
                    LogEvent log = new LogEvent();
                    log.LogWrite(ex.Message);
                    return null;
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        public DataSet SetCancelarSaldoDevolucion(SaldoDevolucionDTO saldoCompromiso)
        {
            if (saldoCompromiso == null) return null;
            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_SET_CancelarSaldoDevolucion]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@devolucionId", saldoCompromiso.devolucionId);
                        command.Parameters.AddWithValue("@usuarioId", saldoCompromiso.usuarioId);
                        command.CommandTimeout = 0;
                        var adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataSet);
                    }
                    return dataSet;
                }
                catch (System.Exception ex)
                {
                    LogEvent log = new LogEvent();
                    log.LogWrite(ex.Message);
                    return null;
                }
                finally
                {
                    connection.Close();
                }

            }
        }


        public DataSet GetPedidoDetalleDevolucion(DevolucionUbicacionPedidosDTO depachoCambio)
        {
            if (depachoCambio == null) return null;
            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_Get_PedidoDetalleDevolucion]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@puertaId", depachoCambio.puertaId);
                        command.Parameters.AddWithValue("@usuarioId", depachoCambio.usuarioId);
                        command.CommandTimeout = 0;
                        var adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataSet);
                    }
                    return dataSet;
                }
                catch (System.Exception ex)
                {
                    LogEvent log = new LogEvent();
                    log.LogWrite(ex.Message);
                    return null;
                }
                finally
                {
                    connection.Close();
                }

            }
        }



    }
}
