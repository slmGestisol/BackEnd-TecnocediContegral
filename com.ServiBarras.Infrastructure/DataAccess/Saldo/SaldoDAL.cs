using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.LogEvent;
using com.ServiBarras.Shared.ModelDTO;
using com.ServiBarras.Shared.SqlData;
using com.ServiBarras.Shared.Utils;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class SaldoDAL : ISaldoDAL
    {
        public TecnoCEDI_bdContext dbcontext;
        /// <summary>
        /// Constructor, geneta una instancia del contexto de la base de datos
        /// </summary>
        public SaldoDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }


        public DataSet GetSaldoDetalleByUbicacionId(long ubicacionId,long contenedorId)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_SaldoDetalleByUbicacionId]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ubicacionId", ubicacionId);
                        command.Parameters.AddWithValue("@contenedorId", contenedorId);

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

        public DataSet GetSaldoDetalleByContenedorCodigo(ConsultarContenedoresDTO contenedoresAUX)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_SaldoDetalleByContenedorCodigo]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@contenedorCodigo", contenedoresAUX.contenedorCodigo);
                        command.Parameters.AddWithValue("@ContenedorHermanos", contenedoresAUX.contenedoresHermanos);

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


        public DataSet SetDescargaSaldoParcial(DescargaSaldoDTO saldoAux)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_SET_DescargaSaldoParcial]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UsuarioId", saldoAux.usuarioId);
                        command.Parameters.AddWithValue("@UbicacionCodigoCapturada", saldoAux.ubicacionCodigo);
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


        public DataSet setReubicacionSaldoParcial(SaldoReubicacionParcialDTO SaldoReubicacionParcialDTO)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[sp_SET_ReubicacionParcial]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UsuarioId", SaldoReubicacionParcialDTO.usuarioId);
                        command.Parameters.AddWithValue("@ContenedorId", SaldoReubicacionParcialDTO.contenedorId);
                        command.Parameters.AddWithValue("@ubicacionId", SaldoReubicacionParcialDTO.ubicacionId);
                        command.Parameters.AddWithValue("@tipoMovimiento", SaldoReubicacionParcialDTO.tipoMovimiento);
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


        public string SetAjustarSaldo(List<SaldoAjusteDTO> saldoAux)
        {
            if (saldoAux == null) return null;

            if (saldoAux.Count == 0) return null;

            string result = string.Empty;
            List<SaldoDetalleDTO> sDetalleList = new List<SaldoDetalleDTO>();
            SaldoDetalleDTO sDetalleItem = new SaldoDetalleDTO();
            decimal cantEscalar = 0;
            decimal cantUnidades = 0;

            try
            {

                //var saldosDetalleActualItem = dbcontext.SaldosDetalle.Where(x => x.ubicacionId == saldoAux[0].ubicacionId).ToList();



                 using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
                 {
                     connection.Open();
                     using (var command = new SqlCommand("[dbo].[sp_SET_TxInventario]", connection))
                     {
                         command.CommandType = System.Data.CommandType.StoredProcedure;
                         command.Parameters.AddWithValue("@usuarioId", saldoAux[0].usuarioId);
                         command.Parameters.AddWithValue("@ubicacionId", saldoAux[0].ubicacionId);
                         command.Parameters.AddWithValue("@concepto", 1);
                         command.CommandTimeout = 0;
                         command.ExecuteNonQuery();
                     }
                 }

                dbcontext.SaldosDetalle.RemoveRange(dbcontext.SaldosDetalle.Where(x => x.ubicacionId == saldoAux[0].ubicacionId));
                var data = saldoAux.Where(x => x.selected);

                if (data == null)
                {
                    dbcontext.SaveChanges();
                    result = "El ajuste se ha procesado correctamente";
                    return result;
                }

                if (data.Count() == 0)
                {
                    dbcontext.SaveChanges();
                    result = "El ajuste se ha procesado correctamente";
                    return result;
                }

                var productoItem = dbcontext.Productos.Where(x => x.productoId == saldoAux[0].productoId).FirstOrDefault();
                
                var presentacionItem = dbcontext.Presentaciones.Where(x => x.presentacionId == saldoAux[0].presentacionId).FirstOrDefault();

                var saldoItem = dbcontext.Saldos.Where(x => x.productoId == saldoAux[0].productoId).FirstOrDefault();

                if (presentacionItem == null)
                {
                    result = "No se encontro saldoId";
                    return result;
                }

                var ordenEmpaqueId = dbcontext.TxOrdenEmpaque.Where(x => x.contenedorId == saldoAux[0].contenedorId).FirstOrDefault();

                if (ordenEmpaqueId == null)
                {
                    result = "No se encontro la orden de empaque para relacionar la fecha de vencimiento";
                    return result;
                }

                if (presentacionItem == null) cantUnidades = 0;
                else
                {
                    decimal cantEscalarAux = 0;
                    cantUnidades = (decimal.TryParse(presentacionItem.presentacionNumUnidad.ToString()
                                            , out cantEscalarAux)) ? cantEscalarAux : 0;
                }


                if (productoItem == null) cantEscalar = 0;
                else
                {
                    decimal cantEscalarAux = 0;
                    cantEscalar = (decimal.TryParse(productoItem.productoCantidadEscalar.ToString()
                                            , out cantEscalarAux)) ? cantEscalarAux : 0;
                }

                var saldoid = saldoItem.saldoId;
                long ValorLoteId = long.Parse(ordenEmpaqueId.valorProductoLoteId.ToString());

                foreach (var saldoDetalleItem in saldoAux.Where(x => x.selected))
                {
                    sDetalleItem = new SaldoDetalleDTO();
                    sDetalleItem.saldoId = saldoid;
                    sDetalleItem.contenedorId = saldoDetalleItem.contenedorId;
                    sDetalleItem.bodegaLogicaId = saldoDetalleItem.bodegaLogicaId;
                    sDetalleItem.ubicacionId = saldoDetalleItem.ubicacionId;
                    sDetalleItem.valorProductoLoteId = ValorLoteId;
                    sDetalleItem.presentacionId = saldoDetalleItem.presentacionId;
                    sDetalleItem.saldoDetalleRealManejo = 1;
                    sDetalleItem.saldoDetalleComprometidoManejo = 0;
                    sDetalleItem.saldoDetalleInmovilizadoManejo = 0;
                    sDetalleItem.saldoDetalleDisponibleManejo = 1;
                    sDetalleItem.saldoDetalleRealEscalar =  cantEscalar * cantUnidades;
                    sDetalleItem.saldoDetalleComprometidoEscalar = 0;
                    sDetalleItem.saldoDetalleInmovilizadoEscalar = 0;
                    sDetalleItem.saldoDetalleDisponibleEscalar = cantEscalar * cantUnidades;

                    sDetalleList.Add(sDetalleItem);
                }

                DataTable dataInsert = ConverterObject.CreateDataTable(sDetalleList);
                SqlObjectData sqlObjectData = new SqlObjectData();
                sqlObjectData.BulkInsertDataTable("[dbo].[saldosDetalle]", dataInsert, dbcontext.Database.GetDbConnection().ConnectionString);
                dbcontext.SaveChanges();

                using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand("[dbo].[sp_SET_TxInventario]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@usuarioId", saldoAux[0].usuarioId);
                        command.Parameters.AddWithValue("@ubicacionId", saldoAux[0].ubicacionId);
                        command.Parameters.AddWithValue("@concepto", 2);
                        command.CommandTimeout = 0;
                        command.ExecuteNonQuery();
                    }
                }
                /* using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
                 {
                     connection.Open();
                     using (var command = new SqlCommand("[dbo].[SP_SET_IntegracionAjusteInventario]", connection))
                     {
                         command.CommandType = System.Data.CommandType.StoredProcedure;
                         command.Parameters.AddWithValue("@ubicacionId", saldoAux[0].ubicacionId);
                         command.Parameters.AddWithValue("@saldoId", saldoAux[0].saldoId);
                         command.Parameters.AddWithValue("@usuarioId", saldoAux[0].usuarioId);
                         command.CommandTimeout = 0;
                         command.ExecuteNonQuery();
                     }
                 }*/

                result = "El ajuste se ha procesado correctamente";
            }
            catch (Exception ex)
            {
                LogEvent log = new LogEvent();
                log.LogWrite(ex.Message);

                return "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";

            }


            return result;

        }

        public DataSet SetSaldoReubicacion(SaldoReubicacionDTO saldoReubicacionAux)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_SET_SaldoReubicacion]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@saldoId", saldoReubicacionAux.saldoId);
                        command.Parameters.AddWithValue("@ubicacionOrigenId", saldoReubicacionAux.ubicacionOrigenId);
                        command.Parameters.AddWithValue("@productoId", saldoReubicacionAux.productoId);
                        command.Parameters.AddWithValue("@presentacionId", saldoReubicacionAux.presentacionId);
                        command.Parameters.AddWithValue("@fechaSaldo", saldoReubicacionAux.fechaSaldo);
                        command.Parameters.AddWithValue("@novedadId", saldoReubicacionAux.novedadId = (saldoReubicacionAux.novedadId == null) ? 0 : saldoReubicacionAux.novedadId);
                        command.Parameters.AddWithValue("@usuarioId", saldoReubicacionAux.usuarioId);
                        command.Parameters.AddWithValue("@tipoMovimientoSaldo", saldoReubicacionAux.tipoMovimientoSaldo);
                        command.Parameters.AddWithValue("@sugeridoPosicionSeleccionada", saldoReubicacionAux.sugeridoPosicionSeleccionada);
                        command.Parameters.AddWithValue("@contenedorId", saldoReubicacionAux.contenedorId);

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

        public DataSet ValidarSaldoCargaUsuario(long usuarioId)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_ValidarSaldoCargaUsuario]", connection))
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

        public DataSet GetUbicacionesProductoSugerida(UbicacionProductoDTO ubicacionProductoDTO)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_UbicacionesProductoSugerida]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@productoId", ubicacionProductoDTO.productoId);
                        command.Parameters.AddWithValue("@presentacionId", ubicacionProductoDTO.presentacionId);
                        command.Parameters.AddWithValue("@FechaSaldo", ubicacionProductoDTO.FechaSaldo);
                        command.Parameters.AddWithValue("@usuarioId", ubicacionProductoDTO.usuarioId);

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

        public DataSet SetSaldoReubicacionBarcode(SaldoReubicacionDTO saldoReubicacionAux)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_SET_SaldoReubicacionBarcode]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ubicacionOrigenId", saldoReubicacionAux.ubicacionOrigenId);
                        command.Parameters.AddWithValue("@contenedorEstibaConsecutivo", saldoReubicacionAux.contenedorEstibaConsecutivo);
                        command.Parameters.AddWithValue("@presentacionId", saldoReubicacionAux.presentacionId);
                        //command.Parameters.AddWithValue("@fechaSaldo", saldoReubicacionAux.fechaSaldo);
                        command.Parameters.AddWithValue("@novedadId", saldoReubicacionAux.novedadId = (saldoReubicacionAux.novedadId == null) ? 0 : saldoReubicacionAux.novedadId);
                        command.Parameters.AddWithValue("@novedadAccionId", saldoReubicacionAux.novedadAccionId);
                        command.Parameters.AddWithValue("@usuarioId", saldoReubicacionAux.usuarioId);
                        command.Parameters.AddWithValue("@tipoMovimientoSaldo", saldoReubicacionAux.tipoMovimientoSaldo);
                        command.Parameters.AddWithValue("@sugeridoPosicionSeleccionada", saldoReubicacionAux.sugeridoPosicionSeleccionada);

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


        public DataSet ValidarSaldoUsuarioReubicacionBarcode(long usuarioId)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_ValidarSaldoUsuarioReubicacionBarcode]", connection))
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

        public DataSet setDescomprometerUbicacion(SaldoDescomprometerUbicacionDTO saldoDescomprometerUbicacion)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[sp_SET_DescomprometerUbicacionDespacho]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UsuarioId", saldoDescomprometerUbicacion.usuarioId);
                        command.Parameters.AddWithValue("@ubicacionCodigo", saldoDescomprometerUbicacion.ubicacionCodigo);
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

        public DataSet setReubicarEstiba(ReubicacionEstibaDTO reubicacionEstibaDTO)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[sp_SET_ReubicarSaldoEstiba]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@EstibaCodigoOrigen", reubicacionEstibaDTO.estibaCodigoOrigen);
                        command.Parameters.AddWithValue("@EstibaCodigoDestino", reubicacionEstibaDTO.estibaCodigoDestino);
                        command.Parameters.AddWithValue("@cantidad", reubicacionEstibaDTO.cantidad);
                        command.Parameters.AddWithValue("@usuarioId", reubicacionEstibaDTO.usuarioId);
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

        public DataSet setLimpiarEstiba(LimpiarEstibaDTO limpiarEstibaDTO)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[sp_SET_LimpiarEstibas]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@contenedorId", limpiarEstibaDTO.contenedorId);
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

        public DataSet setAjustarEstiba(AjustarEstibaDTO parametrosAjustarEstiba)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[sp_SET_AjusteInventarioByEstiba]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@contenedorCodigo", parametrosAjustarEstiba.contenedorCodigo);
                        command.Parameters.AddWithValue("@productoId", parametrosAjustarEstiba.productoId);
                        command.Parameters.AddWithValue("@usuarioId", parametrosAjustarEstiba.usuarioId);
                        command.Parameters.AddWithValue("@Cantidad", parametrosAjustarEstiba.Cantidad);
                        command.Parameters.AddWithValue("@loteCodigo", parametrosAjustarEstiba.loteCodigo);
                        command.Parameters.AddWithValue("@proceso", parametrosAjustarEstiba.proceso);
                        command.Parameters.AddWithValue("@loteFechaVencimiento", parametrosAjustarEstiba.fechaVencimientoLote);



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
