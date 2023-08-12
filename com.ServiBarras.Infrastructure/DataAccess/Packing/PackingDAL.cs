using System.Data;
using System.Data.SqlClient;
using System.Linq;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.LogEvent;
using com.ServiBarras.Shared.ModelDTO;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class PackingDAL : IPackingDAL
    {
        public TecnoCEDI_bdContext dbcontext;
        /// <summary>
        /// Constructor, genera una instancia del contexto de la base de datos
        /// </summary>
        public PackingDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }

        public DataSet SPPackingRuteo(PackingDTO packingDTO)
        {

            if (packingDTO == null) return null;
            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_SET_PackingRuteo]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@packingId", packingDTO.packingId);
                        command.Parameters.AddWithValue("@packingDetalleId", packingDTO.packingDetalleId);                       
                        command.Parameters.AddWithValue("@usuarioId", packingDTO.usuarioId);
                        command.Parameters.AddWithValue("@ruteoId", packingDTO.ruteoId);
                        command.Parameters.AddWithValue("@ruteoDetalleId", packingDTO.ruteoDetalleId);
                        command.Parameters.AddWithValue("@novedadId", (packingDTO.novedadId = (packingDTO.novedadId == null) ? 0 : packingDTO.novedadId));
                        command.Parameters.AddWithValue("@novedadAccionId", (packingDTO.novedadAccionId = (packingDTO.novedadAccionId == null) ? 0 : packingDTO.novedadAccionId));
                        command.Parameters.AddWithValue("@codigoUbicacionBahia", packingDTO.codigoUbicacionBahia);
                        command.Parameters.AddWithValue("@continuidadActivada", packingDTO.continuidadActivada);

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

        public DataSet GetPackingDetallebyPackingId(PackingDetalleDTO packingDto)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_packingDetalle]", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@packingId", packingDto.packingId);
                        command.Parameters.AddWithValue("@packingDetalleId", packingDto.packingDetalleId);
                        command.Parameters.AddWithValue("@packingDetalleGlobalId", packingDto.packingDetalleGlobalId);
                        //command.Parameters.AddWithValue("@ubicacionBahiaId", packingDto.ubicacionbahiaId);
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

        public string GetUbicacionByUserTag(long usuarioId)
        {
            string ubicacionTag = "";
            var user = dbcontext.Usuarios.Where(x => x.usuarioId == usuarioId).FirstOrDefault();

            if (user == null) return "";

            var ubicacionRfId = dbcontext.RFIDTag.Where(x => x.RFIDTagMaquina == user.usuarioUser).FirstOrDefault();

            if (ubicacionRfId == null) ubicacionTag = "";
            else ubicacionTag = ubicacionRfId.RFIDTagEPC.Substring(8);

            return ubicacionTag;
        }




        public DataSet PackingDetalleUsuarioId(long? usuarioId)
        {
            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_packingDetalle_ubicacionCodigo]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@usuarioId", usuarioId);
                        command.CommandTimeout = 0;

                        var adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataSet);
                        if (dataSet == null) return null;
                        if (dataSet.Tables.Count == 0) return null;
                        if (dataSet.Tables[0].Rows.Count == 0) return null;
                        string result = dataSet.Tables[0].Rows[0]["resultado"].ToString();

                        if (string.IsNullOrEmpty(result)) return null;
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
