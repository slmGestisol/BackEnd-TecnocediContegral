using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.LogEvent;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess.MonitorOperario
{
    public class MonitorOperarioDAL : IMonitorOperarioDAL
    {
        public TecnoCEDI_bdContext dbcontext;

        public MonitorOperarioDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }

        public Task<DataSet> GetInformacionReubicacionByUsuarioIdAsync(long usuarioId)
        {
            // Extraer el connection string ANTES del Task.Run — DbContext no es thread-safe
            string connectionString = dbcontext.Database.GetDbConnection().ConnectionString;
            return Task.Run(() =>
            {
                var dataSet = new DataSet();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    try
                    {
                        using (var command = new SqlCommand("[dbo].[sp_GET_informacionReubicacionByUsuarioId]", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@usuarioId", usuarioId);
                            command.CommandTimeout = 0;
                            var adapter = new SqlDataAdapter(command);
                            adapter.Fill(dataSet);
                        }
                        return dataSet;
                    }
                    catch (Exception ex)
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
            });
        }

        public Task<DataSet> GetInformacionPickingByUsuarioIdAsync(long usuarioId)
        {
            // Extraer el connection string ANTES del Task.Run — DbContext no es thread-safe
            string connectionString = dbcontext.Database.GetDbConnection().ConnectionString;
            return Task.Run(() =>
            {
                var dataSet = new DataSet();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    try
                    {
                        using (var command = new SqlCommand("[dbo].[sp_GET_informacionPickingByUsuarioId]", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@usuarioId", usuarioId);
                            command.CommandTimeout = 0;
                            var adapter = new SqlDataAdapter(command);
                            adapter.Fill(dataSet);
                        }
                        return dataSet;
                    }
                    catch (Exception ex)
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
            });
        }

        public Task<DataSet> GetInformacionDespachoByUsuarioIdAsync(long usuarioId)
        {
            // Extraer el connection string ANTES del Task.Run — DbContext no es thread-safe
            string connectionString = dbcontext.Database.GetDbConnection().ConnectionString;
            return Task.Run(() =>
            {
                var dataSet = new DataSet();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    try
                    {
                        using (var command = new SqlCommand("[dbo].[sp_GET_informacionDespachoByUsuarioId]", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@usuarioId", usuarioId);
                            command.CommandTimeout = 0;
                            var adapter = new SqlDataAdapter(command);
                            adapter.Fill(dataSet);
                        }
                        return dataSet;
                    }
                    catch (Exception ex)
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
            });
        }

    }
}
