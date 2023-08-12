using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.LogEvent;
using com.ServiBarras.Shared.ModelDTO;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class UbicacionDAL : IUbicacionDAL
    {
        public TecnoCEDI_bdContext dbcontext;
        /// <summary>
        /// Constructor, geneta una instancia del contexto de la base de datos
        /// </summary>
        public UbicacionDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }

        /// <summary>
        /// Método que consulta las ubicaciones
        /// </summary>
        /// <returns></returns>
        public async Task<List<Ubicaciones>> GetUbicacionesAsync()
        {
            return await dbcontext.Ubicaciones.ToListAsync();
        }


        /// <summary>
        /// Método que consulta una ubicacion según el ubicacionId
        /// </summary>
        /// <param name="ubicacionId"></param>
        /// <returns></returns>
        public async Task<Ubicaciones> GetUbicacionAsync(long ubicacionId)
        {
            var ubicacion = await dbcontext.Ubicaciones.FindAsync(ubicacionId);
            return ubicacion;
        }

        public async Task<List<Ubicaciones>> GetUbicacionesByTipoUbicacionAsync(FilterBahiaDTO FilterBahiaDTO)
        {
            if (FilterBahiaDTO.tipoUbicacionId == 2)
            {
                return await dbcontext.Ubicaciones.Where(x => x.tipoUbicacionId == FilterBahiaDTO.tipoUbicacionId && x.instalacionId == FilterBahiaDTO.instalacionId
                && x.ubicacionCodigo != "01BAHIA08" && x.ubicacionCodigo != "01BAHIA00" && x.ubicacionDespacho == false).ToListAsync();
            }
            else
            {
                return await dbcontext.Ubicaciones.Where(x => x.tipoUbicacionId == FilterBahiaDTO.tipoUbicacionId).ToListAsync();
            }
        }

        public DataSet GetCodigoReubicacionByUsuarioId(long usuarioId)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_CodigoreUbicacionByUsuarioId]", connection))
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
        public DataSet GetContenedoresByUbicacionesCodigo(string ubicacionCodigo)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_ContenedoresUbicacionCodigo]", connection))
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

    

        public DataSet GetBahiasDisponiblesByBahiaPadre(UbicacionContingenciaDTO ubicacionContingenciaDTO)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_BahiasDisponiblesByBahiaPadre]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@bahiaPadreId", ubicacionContingenciaDTO.bahiaPadreId);
                        command.Parameters.AddWithValue("@esDespacho", ubicacionContingenciaDTO.esDespacho);
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

        public DataSet GetDespachoParcialUbicaciones(long instalacionId)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_DespachoParcialUbicaciones]", connection))
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

        public DataSet GetCodigoUbicacionByUsuarioId(long usuarioId)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_CodigoUbicacionByUsuarioId]", connection))
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


        public DataSet GetUbicacionByUbicacionCodigo(string ubicacionCodigo)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_UbicacionByUbicacionCodigo]", connection))
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

        public DataSet getPuertasUbicaciones(long instalacionId)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_PuertasUbicaciones]", connection))
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
                    return dataSet;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public DataSet getruteoDetalleUbicacionCapturada(string ubicacionRequerida, string ubicacionCapturada)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_RuteoDetalle_ubicacionCapturada]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ubicacionRequerida", ubicacionRequerida);
                        command.Parameters.AddWithValue("@ubicacionCapturada", ubicacionCapturada);
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
                    return dataSet;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public string GetCodigoUbicacionByBahiaPadreId(UbicacionDTO ubicacionDTO)
        {
            string rFIDTagEPC = "";   
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_CodigoUbicacionByBahiaPadreId]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@bahiaPadreId", ubicacionDTO.bahiaPadreId);
                        command.Parameters.AddWithValue("@usuarioId", ubicacionDTO.usuarioId);
                        command.CommandTimeout = 0;
                        var adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataSet);
                        if (dataSet == null) return "";
                        if (dataSet.Tables.Count == 0) return "";
                        if (dataSet.Tables[0].Rows.Count == 0) return "";
                        rFIDTagEPC = dataSet.Tables[0].Rows[0]["RFIDTagEPC"].ToString();
                        if (string.IsNullOrEmpty(rFIDTagEPC)) return "";
                    }
                    return rFIDTagEPC;
                }
                catch (System.Exception ex)
                {
                    LogEvent log = new LogEvent();
                    log.LogWrite(ex.Message);
                    return "";
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public string GetCodigoUbicacionPuertaByBahiaId(long bahiaId)
        {
            string ubicacionTag = "";
            var ubicacionBahia = dbcontext.Ubicaciones.Where(x => x.ubicacionId == bahiaId).FirstOrDefault();
            if (ubicacionBahia == null) return "";
            var ubicacionPuerta = dbcontext.Ubicaciones.Where(x => x.ubicacionId == ubicacionBahia.ubicacionPadreId).FirstOrDefault();
            if (ubicacionPuerta == null) ubicacionTag = "";
            else ubicacionTag = ubicacionPuerta.ubicacionCodigo;
            return ubicacionTag;
        }


        public DataSet GetUbicacionByUbicacionCodigoBarcode(string ubicacionCodigo)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_UbicacionByUbicacionCodigoBarcode]", connection))
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
    }
}