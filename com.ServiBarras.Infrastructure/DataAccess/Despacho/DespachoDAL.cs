using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.LogEvent;
using com.ServiBarras.Shared.ModelDTO;
using Microsoft.EntityFrameworkCore;
using com.ServiBarras.Shared.SqlData;
using com.ServiBarras.Shared.Utils;


namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class DespachoDAL : IDespachoDAL
    {
        public TecnoCEDI_bdContext dbcontext;
        /// <summary>
        /// Constructor, genera una instancia del contexto de la base de datos
        /// </summary>
        public DespachoDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }
        /// <summary>
        /// Método que consulta los PreRuteos
        /// </summary>
        /// <returns></returns>


        public DataSet SPDespachoRuteo(DespachoDTO despachoDTO)
        {

            if (despachoDTO == null) return null;



            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_SET_DespachoRuteo]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@despachoId", despachoDTO.despachoId);
                        command.Parameters.AddWithValue("@despachoDetalleId", despachoDTO.despachoDetalleId);
                        command.Parameters.AddWithValue("@ubicacionCodigo", despachoDTO.ubicacionCodigo);
                        command.Parameters.AddWithValue("@novedadId", (despachoDTO.novedadId = (despachoDTO.novedadId == null) ? 0 : despachoDTO.novedadId));
                        command.Parameters.AddWithValue("@novedadAccionId", (despachoDTO.novedadAccionId = (despachoDTO.novedadAccionId == null) ? 0 : despachoDTO.novedadAccionId));
                        command.Parameters.AddWithValue("@usuarioId", despachoDTO.usuarioId);
                        command.Parameters.AddWithValue("@continuidadActivada", despachoDTO.continuidadActivada);
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

        public DataSet ValidarDespachoParcialCargaUsuario(long usuarioId)
        {

            if (usuarioId == 0) return null;



            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {

                connection.Open();
                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_GET_ValidarDespachoParcialCargaUsuario]", connection))
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

        public DataSet GetPedidosDespachos(PedidosDespachoDTO pedidosDespachosAux)
        {

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_GET_PedidosDespacho]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ubicacionIdPuerta", pedidosDespachosAux.ubicacionIdPuerta);
                        command.Parameters.AddWithValue("@pedidos", pedidosDespachosAux.pedidos);
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

        public DataSet CancelarLineaDespachoParcial(DespachoParcialPedidosDTO despachoAux)
        {
            if (despachoAux == null) return null;



            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_SET_CancelarLineaDespachoParcial]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PedidoId", despachoAux.pedidoId);
                        command.Parameters.AddWithValue("@PresentacionId", despachoAux.PresentacionId);
                        command.Parameters.AddWithValue("@usuarioId", despachoAux.usuarioId);
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

        public DataSet GetProductoDespachoReciente(PedidosDespachoDTO pedidosDespachosAux)
        {

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_GET_ProductoDespachoReciente]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ubicacionIdPuerta", pedidosDespachosAux.ubicacionIdPuerta);
                        command.Parameters.AddWithValue("@pedidos", pedidosDespachosAux.pedidos);
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



        public DataSet GetDespachobyUbicacionidpuerta(long ubicacionIdPuerta)
        {



            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_GET_DespachoByUbicacionIdPuerta]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ubicacionIdPuerta", ubicacionIdPuerta);

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

        public DataSet ValidarDespachoCargaUsuario(long usuarioId)
        {

            if (usuarioId == 0) return null;



            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {

                connection.Open();
                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_GET_ValidarDespachoCargaUsuario]", connection))
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



        public DataSet GetDespachoDetalleByUbicacionCodigo(string ubicacionCodigo)
        {


            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {

                connection.Open();
                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_GET_DespachoDetalleByUbicacion]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ubicacionCodigo", ubicacionCodigo);


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


        public DataSet GetDespachoDetalleUbicacionDestino(long despachoDetalleId)
        {


            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {

                connection.Open();
                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_GET_DespachoDetalleUbicacionDestino]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@despachoDetalleId", despachoDetalleId);


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



        public DataSet GetDespachoArqueo(long ubicacionPuertaId)
        {


            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {

                connection.Open();
                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_GET_DespachoArqueo]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ubicacionPuertaId", ubicacionPuertaId);


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


        public DataSet SPDespachoPacialRuteo(List<DespachoParcialDTO> DespachoParcialDTO)
        {

            if (DespachoParcialDTO == null) return null;

            var dataSet = new DataSet();

            SqlObjectData SqlObjectData = new SqlObjectData();
            //onverterObject converterObject = new ConverterObject();

            DataTable pedidosSeleccionados = ConverterObject.CreateDataTable(DespachoParcialDTO);
            SqlObjectData.BulkInsertDataTable("ContenedoresDespachoParcial", pedidosSeleccionados, dbcontext.Database.GetDbConnection().ConnectionString);

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[sp_SET_DespachoParcialRuteo]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UsuarioId", DespachoParcialDTO[0].usuarioId);
                        command.Parameters.AddWithValue("@EstibaId", DespachoParcialDTO[0].EstibaId);
                        command.Parameters.AddWithValue("@ContenedorId", DespachoParcialDTO[0].ContenedorId);
                        command.Parameters.AddWithValue("@PuertaId", DespachoParcialDTO[0].PuertaId);
                        command.Parameters.AddWithValue("@PedidoId", DespachoParcialDTO[0].PedidoId);
                        command.Parameters.AddWithValue("@incompleto", DespachoParcialDTO[0].Incomincompleto);
                        command.Parameters.AddWithValue("@uniqueidentifier", DespachoParcialDTO[0].uniqueProcessId);


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

        public DataSet setDespachoPickingPacking(DespachoPickingPackingDTO DespachoPickingPackingDTO)
        {

            if (DespachoPickingPackingDTO == null) return null;

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_SET_DespachoPickingPackingRuteo_cursor]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ruteoId", DespachoPickingPackingDTO.ruteoId);
                        command.Parameters.AddWithValue("@UsuarioId", DespachoPickingPackingDTO.usuarioId);

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


        public DataSet SPPedidosDespachoParcial(DespachoParcialPedidosDTO DespachoParcialPedidosDTO)
        {

            if (DespachoParcialPedidosDTO == null) return null;



            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_GET_PedidosDespachoParcial]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PresentacionId", DespachoParcialPedidosDTO.PresentacionId);
                        command.Parameters.AddWithValue("@UbicacionId", DespachoParcialPedidosDTO.UbicacionId);
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


        public DataSet SPCerrarDespachoBahiaRuteo(DespachoBahiaRuteoDTO despachoBahiaRuteoDTO)
        {

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_SET_CerrarDespachoBahiaRuteo]", connection))
                    {
                        
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@puertaUbicacionId", despachoBahiaRuteoDTO.puertaUbicacionId);                       
                        command.Parameters.AddWithValue("@usuarioId", despachoBahiaRuteoDTO.usuarioId);
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

        public DataSet DespachoLibreCrearDocumento(DespachoLibreCrearDocumento despachoLibreCrearDocumento)
        {

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[sp_SET_DespachoLibreCrearDocumento]", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@bahiaId", despachoLibreCrearDocumento.bahiaId);
                        command.Parameters.AddWithValue("@documentoERP", despachoLibreCrearDocumento.documentoERP);
                        command.Parameters.AddWithValue("@usuarioId", despachoLibreCrearDocumento.usuarioId);

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

        public DataSet setDespachoLibreDocumentoCerrar(DespachoLibreCerrarDocumento parametrosDespachoLibreCerrarDocumento)
        {

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[sp_SET_DespachoLibreCierre]", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ubicacionId", parametrosDespachoLibreCerrarDocumento.ubicacionId);
                        command.Parameters.AddWithValue("@documentoERP", parametrosDespachoLibreCerrarDocumento.documentoERP);
                        command.Parameters.AddWithValue("@usuarioId", parametrosDespachoLibreCerrarDocumento.usuarioId);
                        command.Parameters.AddWithValue("@cerrarDocumentosAsociados", parametrosDespachoLibreCerrarDocumento.cerrarDocumentosAsociados);


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

        public DataSet getDespachoLibrePuertas(bool parcial)
        {

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[sp_GET_DespachoLibrePuertas]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@parcial", parcial);

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

        public DataSet getDespachoLibrePuertasDetalle(string documentoERP, bool parcial)
        {

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[sp_GET_DespachoLibrePuertasDetalle]", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@parcial", parcial);
                        command.Parameters.AddWithValue("@documentoERP", documentoERP);
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
        public DataSet getDespachoLibreInformacionDespacho(string documentoERP,long productoId)
        {

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[sp_GET_DespachoLibreInformacionDespacho]", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@documentoERP", documentoERP);
                        command.Parameters.AddWithValue("@productoId", productoId);

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

        public DataSet setDespachoLibreDocumentoProcesar(DespachoLibreProcesarDocumento parametrosDespachoLibreProcesarDocumento)
        {

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[sp_SET_DespachoLibreDocumentoProcesar]", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@usuarioId", parametrosDespachoLibreProcesarDocumento.usuarioId);
                        command.Parameters.AddWithValue("@documentoERP", parametrosDespachoLibreProcesarDocumento.documentoERP);
                        command.Parameters.AddWithValue("@estibaCodigo", parametrosDespachoLibreProcesarDocumento.estibaCodigo);
                        command.Parameters.AddWithValue("@cantidad", parametrosDespachoLibreProcesarDocumento.cantidad);
                        command.Parameters.AddWithValue("@productoId", parametrosDespachoLibreProcesarDocumento.productoId);
                        command.Parameters.AddWithValue("@ubicacionIdDestino", parametrosDespachoLibreProcesarDocumento.ubicacionIdDestino);
                        command.Parameters.AddWithValue("@estibaCodigoDestino", parametrosDespachoLibreProcesarDocumento.estibaCodigoDestino);
                        command.Parameters.AddWithValue("@loteId", parametrosDespachoLibreProcesarDocumento.loteId);
                        command.Parameters.AddWithValue("@proceso", parametrosDespachoLibreProcesarDocumento.proceso);




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

        public DataSet setDespachoLibreCambiarPuerta(DespachoLibreCambioPuerta parametrosDespachoLibreCambiarPuerta)
        {

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[sp_SET_DespachoLibreCambiarPuerta]", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@usuarioId", parametrosDespachoLibreCambiarPuerta.usuarioId);
                        command.Parameters.AddWithValue("@documentoERP", parametrosDespachoLibreCambiarPuerta.documentoERP);
                        command.Parameters.AddWithValue("@ubicacionId", parametrosDespachoLibreCambiarPuerta.ubicacionId);


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

        public DataSet getDespachoLotesPuerta(long ubicacionid, long productoId)
        {

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[sp_GET_DespachosLotesPuerta]", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ubicacionId", ubicacionid);
                        command.Parameters.AddWithValue("@productoId", productoId);

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