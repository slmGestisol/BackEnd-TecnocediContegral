using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.LogEvent;
using com.ServiBarras.Shared.ModelDTO;
using com.ServiBarras.Shared.SqlData;
using com.ServiBarras.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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


        public DataSet GetSaldoDetalleByUbicacionId(long ubicacionId)
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

        public DataSet GetSaldoDetalleByUbicacionUbicacionCodigo(long ubicacionId, string ubicacionCodigo)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_SaldoDetalleByUbicacionCodigo]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ubicacionId", ubicacionId);
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

        public DataSet GetSaldoDetalleContenedoresByUbicacionUbicacionCodigo(string ubicacionCodigo, long instalacionId)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_SaldoDetalleContenedoresByUbicacionCodigo]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ubicacionCodigo", ubicacionCodigo);
                        command.Parameters.AddWithValue("@instalacionId", instalacionId);

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


        public DataSet setReubicacionSaldoParcial(string proceso,List<SaldoReubicacionParcialDTO> SaldoReubicacionParcialDTO)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {
                    DataTable dataInsert = ConverterObject.CreateDataTable(SaldoReubicacionParcialDTO);
                    SqlObjectData sqlObjectData = new SqlObjectData();
                    sqlObjectData.BulkInsertDataTable("[dbo].[contenedoresReubicacionaParcial]", dataInsert, dbcontext.Database.GetDbConnection().ConnectionString);
                    dbcontext.SaveChanges();

                    using (var command = new SqlCommand("[dbo].[sp_SET_ReubicacionParcial]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@uniqueProcessId", SaldoReubicacionParcialDTO[0].uniqueProcessId);
                        command.Parameters.AddWithValue("@proceso",proceso);
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


        public async Task<string> SetAjustarSaldo(List<SaldoAjusteDTO> saldoAux)
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
                         command.Parameters.AddWithValue("@novedadId", saldoAux[0].novedadId);
                         command.Parameters.AddWithValue("@nota", saldoAux[0].nota);
                        command.CommandTimeout = 0;
                         await command.ExecuteNonQueryAsync();
                     }
                 }

                dbcontext.SaldosDetalle.RemoveRange(dbcontext.SaldosDetalle.Where(x => x.ubicacionId == saldoAux[0].ubicacionId));

                await dbcontext.SaveChangesAsync();

                var data = saldoAux.Where(x => x.selected);

                if (data == null)
                {
                    await dbcontext.SaveChangesAsync();
                    result = "El ajuste se ha procesado correctamente";
                    return result;
                }

                if (data.Count() == 0)
                {
                    await dbcontext.SaveChangesAsync();
                    result = "El ajuste se ha procesado correctamente";
                    return result;
                }

                // *** VALIDACIÓN DE BODEGAS LÓGICAS ***
                var (validacionResultado, bodegaLogicaIdValidada) = await setAjustarSaldoValidad(saldoAux);
                if (!string.IsNullOrEmpty(validacionResultado))
                {
                    return validacionResultado; // Retornar el mensaje de error de validación
                }

                var productoItem = dbcontext.Productos.Where(x => x.productoId == saldoAux[0].productoId).FirstOrDefault();
                
                var presentacionItem = dbcontext.Presentaciones.Where(x => x.presentacionId == saldoAux[0].presentacionId).FirstOrDefault();

                var saldoItem = dbcontext.Saldos.Where(x => x.productoId == saldoAux[0].productoId).FirstOrDefault();

                if (presentacionItem == null)
                {
                    result = "No se encontro saldoId";
                    return result;
                }

                //Se busca el lote por orden de empaque, si el contenedor no ingreso por ese proceso se busca por recepcion
                var valorProductoLoteIdAux = dbcontext.TxOrdenEmpaque
                                                      .Where(x => x.contenedorId == saldoAux[0].contenedorId
                                                               && x.valorProductoLoteId != null)
                                                      .Select(x => x.valorProductoLoteId)
                                                      .FirstOrDefault();

                if (valorProductoLoteIdAux == null)
                {
                    valorProductoLoteIdAux = dbcontext.TxRecepcion
                                                      .Where(x => x.contenedorId == saldoAux[0].contenedorId
                                                               && x.valorProductoLoteId != null)
                                                      .OrderByDescending(x => x.txRecepcionId)
                                                      .Select(x => x.valorProductoLoteId)
                                                      .FirstOrDefault();
                }

                if (valorProductoLoteIdAux == null)
                {
                    result = "No se encontro el contenedor ni en orden de empaque ni en recepcion para relacionar la fecha de vencimiento";
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
                long ValorLoteId = valorProductoLoteIdAux.Value;

                foreach (var saldoDetalleItem in saldoAux.Where(x => x.selected))
                {
                    sDetalleItem = new SaldoDetalleDTO();
                    sDetalleItem.saldoId = saldoid;
                    sDetalleItem.contenedorId = saldoDetalleItem.contenedorId;
                    sDetalleItem.bodegaLogicaId = bodegaLogicaIdValidada;
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
                await dbcontext.SaveChangesAsync();

                using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand("[dbo].[sp_SET_TxInventario]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@usuarioId", saldoAux[0].usuarioId);
                        command.Parameters.AddWithValue("@ubicacionId", saldoAux[0].ubicacionId);
                        command.Parameters.AddWithValue("@concepto", 2);
                        command.Parameters.AddWithValue("@novedadId", saldoAux[0].novedadId);
                        command.Parameters.AddWithValue("@nota", saldoAux[0].nota);
                        command.CommandTimeout = 0;
                        await command.ExecuteNonQueryAsync();
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

        private async Task<(string resultado, long bodegaLogicaId)> setAjustarSaldoValidad(List<SaldoAjusteDTO> saldoAux)
        {
            try
            {
                using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
                {
                    await connection.OpenAsync();

           

                    // Crear el DataTable con la estructura del Table Type
                    var dataTable = new DataTable();
                    dataTable.Columns.Add("saldoId", typeof(long));
                    dataTable.Columns.Add("contenedorId", typeof(long));
                    dataTable.Columns.Add("ubicacionId", typeof(long));
                    dataTable.Columns.Add("bodegaLogicaId", typeof(long));
                    dataTable.Columns.Add("saldoDetalleRealManejo", typeof(decimal));
                    dataTable.Columns.Add("presentacionId", typeof(long));
                    dataTable.Columns.Add("productoId", typeof(long));
                    dataTable.Columns.Add("valorProductoLoteId", typeof(long));
                    dataTable.Columns.Add("selected", typeof(bool));
                    dataTable.Columns.Add("usuarioId", typeof(long));

                    var seleccionados = saldoAux.Where(x => x.selected).ToList();

                    Console.WriteLine($"Seleccionados: {seleccionados.Count}");


                    // Llenar el DataTable con los datos seleccionados
                    foreach (var item in seleccionados)
                    {
                        dataTable.Rows.Add(
                            item.saldoId,
                            item.contenedorId,
                            item.ubicacionId,
                            item.bodegaLogicaId,
                            item.saldoDetalleRealManejo,
                            item.presentacionId,
                            item.productoId,
                            item.valorProductoLoteId,
                            item.selected,
                            item.usuarioId ?? (object)DBNull.Value
                        );
                    }

                    Console.WriteLine($"Filas en DataTable: {dataTable.Rows.Count}");


                    using (var command = new SqlCommand("sp_GET_InventarioValidacion", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Parámetro simple
                        command.Parameters.AddWithValue("@ubicacionId", saldoAux[0].ubicacionId);

                        // Parámetro Table Type
                        var parameter = command.Parameters.AddWithValue("@saldoAux", dataTable);
                        parameter.SqlDbType = SqlDbType.Structured;
                        parameter.TypeName = "dbo.SaldoAjusteTableType";

                        // Parámetro de salida para resultado
                        var outputResultado = new SqlParameter("@resultado", SqlDbType.VarChar, -1)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputResultado);

                        // Parámetro de salida para bodega lógica
                        var outputBodegaLogica = new SqlParameter("@bodegaLogicaId", SqlDbType.BigInt)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputBodegaLogica);

                        // Ejecutar
                        await command.ExecuteNonQueryAsync();
                        string resultado = outputResultado.Value?.ToString() ?? string.Empty;
                        long bodegaLogicaId = outputBodegaLogica.Value != DBNull.Value
                        ? Convert.ToInt64(outputBodegaLogica.Value)
                        : 0;

                        return (resultado, bodegaLogicaId);

                    }
                }
            }
            catch (Exception ex)
            {
                LogEvent log = new LogEvent();
                log.LogWrite(ex.Message);
                return ("Error al validar las bodegas lógicas: " + ex.Message, 0);
            }
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
                        command.Parameters.AddWithValue("@checkExportacion", saldoReubicacionAux.isExportacion);
                        command.Parameters.AddWithValue("@procesoTipo", saldoReubicacionAux.proceso);
                        command.Parameters.AddWithValue("@reabastecimientoSolicitudId", saldoReubicacionAux.reabastecimientoSolicitudId);


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
                        command.Parameters.AddWithValue("@checkExportacion", ubicacionProductoDTO.isExportacion);

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

        public DataSet GetUbicacionesSugeridaReintegro(long instalacionId)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_UbicacionesSugeridaReintegro]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@instalacionId", instalacionId);

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
                        command.Parameters.AddWithValue("@proceso", saldoReubicacionAux.proceso);
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

        public DataSet getSaldo()
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[sp_GET_Saldo]", connection))
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
    }
}
