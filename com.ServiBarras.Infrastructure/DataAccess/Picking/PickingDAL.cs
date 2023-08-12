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
    public class PickingDAL : IPickingDAL
    {
        public TecnoCEDI_bdContext dbcontext;
        /// <summary>
        /// Constructor, genera una instancia del contexto de la base de datos
        /// </summary>
        public PickingDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }

        public DataSet SPPickingRuteo(PickingDTO pickingDTO)
        {

            if (pickingDTO == null) return null;



            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_SET_PickingRuteo]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ruteoId", pickingDTO.ruteoId);
                        command.Parameters.AddWithValue("@ruteoDetalleId", pickingDTO.ruteoDetalleId);
                        command.Parameters.AddWithValue("@contenedorTag", pickingDTO.contenedorTag);
                        command.Parameters.AddWithValue("@ubicacionTag", pickingDTO.ubicacionTag);
                        command.Parameters.AddWithValue("@novedadId", (pickingDTO.novedadId == null) ? 0 : pickingDTO.novedadId);
                        command.Parameters.AddWithValue("@novedadAccionId", (pickingDTO.novedadAccionId == null) ? 0 : pickingDTO.novedadAccionId);
                        command.Parameters.AddWithValue("@usuarioId", pickingDTO.usuarioId);
                        command.Parameters.AddWithValue("@bahiaIdDestino", (pickingDTO.bahiaIdDestino == null) ? 0 : pickingDTO.bahiaIdDestino);
                        command.Parameters.AddWithValue("@pedidoId", pickingDTO.pedidoId);
                        command.Parameters.AddWithValue("@ruteoIdAux", pickingDTO.ruteoIdAux);
                        command.Parameters.AddWithValue("@ruteoDetalleIdAux", pickingDTO.ruteoDetalleIdAux);
                        command.Parameters.AddWithValue("@valorProductoLoteIdAux", pickingDTO.valorProductoLoteIdAux);
                        command.Parameters.AddWithValue("@ubicacionIdAux", pickingDTO.ubicacionIdAux);
                        command.Parameters.AddWithValue("@continuidadActivada", pickingDTO.continuidadActivada);
                        //command.Parameters.AddWithValue("@productoId", pickingDTO.productoId);
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


        public DataSet SetPickingPackingRuteo(List<PickingPackingDTO> pickingPackingDTO)
        {

            if (pickingPackingDTO == null) return null;



            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    SqlObjectData SqlObjectData = new SqlObjectData();


                    DataTable contenedoresRuteo = ConverterObject.CreateDataTable(pickingPackingDTO);
                    SqlObjectData.BulkInsertDataTable("contenedoresPicking", contenedoresRuteo, dbcontext.Database.GetDbConnection().ConnectionString);

                    using (var command = new SqlCommand("[dbo].[sp_SET_PickingPackingRuteo]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@usuarioId", pickingPackingDTO[0].usuarioId);
                        command.Parameters.AddWithValue("@uniqueidentifier", pickingPackingDTO[0].uniqueProcessId);
                        command.Parameters.AddWithValue("@ruteoId", pickingPackingDTO[0].ruteoId);
                        command.Parameters.AddWithValue("@ruteoDetalleId", pickingPackingDTO[0].ruteoDetalleId);
                        command.Parameters.AddWithValue("@ubicacionTag", pickingPackingDTO[0].ubicacionTag);
                        command.Parameters.AddWithValue("@pedidoId", pickingPackingDTO[0].pedidoId);
                        command.Parameters.AddWithValue("@ruteoIdAux", pickingPackingDTO[0].ruteoIdAUX);
                        command.Parameters.AddWithValue("@ruteoDetalleIdAux", pickingPackingDTO[0].ruteoDetalleIdAUX);
                        command.Parameters.AddWithValue("@bahiaIdDestino", pickingPackingDTO[0].bahiaIdDestino);
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


        public DataSet getPickingPackingByRuteo(long ruteoId,long ruteoDetalleId)
        {

            if (ruteoId < 1) return null;

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[sp_GET_PickingPackingByRuteo]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;                      
                        command.Parameters.AddWithValue("@ruteoId", ruteoId);
                        command.Parameters.AddWithValue("@ruteoDetalleId", ruteoDetalleId);
                        
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


        public DataSet SetPickingPackingRuteoNovedad(List<PickingPackingNovedadDTO> pickingPackingNovedadDTO)
        {

            if (pickingPackingNovedadDTO == null) return null;



            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    SqlObjectData SqlObjectData = new SqlObjectData();

                    using (var command = new SqlCommand("[dbo].[SP_SET_ReprocesarRuteoDetalle_Parcial]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ruteoId", pickingPackingNovedadDTO[0].ruteoId);
                        command.Parameters.AddWithValue("@ruteoDetalleId", pickingPackingNovedadDTO[0].ruteoDetalleId);
                        command.Parameters.AddWithValue("@ubicacionIdOrigen", pickingPackingNovedadDTO[0].ubicacionIdOrigen);
                        command.Parameters.AddWithValue("@usuarioId", pickingPackingNovedadDTO[0].usuarioId);
                        command.Parameters.AddWithValue("@ruteoDetalleCantRequerida", pickingPackingNovedadDTO[0].ruteoDetalleCantRequerida);
                        
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
