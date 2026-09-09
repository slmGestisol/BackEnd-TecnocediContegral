using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.ModelDTO;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.LogEvent;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess.Reabastecimiento
{
    /// <summary>
    /// Ejecuta sp_GET_ReabastecimientoData reutilizando la misma forma de acceso a datos
    /// del resto del proyecto: ADO.NET sobre la cadena de conexión que expone
    /// TecnoCEDI_bdContext (ver DashboardDAL / MonitorOperarioDAL).
    /// </summary>
    public class ReabastecimientoDAL : IReabastecimientoDAL
    {
        public TecnoCEDI_bdContext dbcontext;

        public ReabastecimientoDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }

        public async Task<IReadOnlyList<ReabastecimientoItemDto>> ObtenerReabastecimientoAsync()
        {
            // Extraer el connection string del contexto (el DbContext no es thread-safe,
            // aquí sólo se usa para leer la cadena, igual que los DAL existentes).
            string connectionString = dbcontext.Database.GetDbConnection().ConnectionString;

            var resultado = new List<ReabastecimientoItemDto>();

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                try
                {
                    using (var command = new SqlCommand("[dbo].[sp_GET_ReabastecimientoData]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 0;

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                resultado.Add(new ReabastecimientoItemDto
                                {
                                    productoId = GetInt(reader, "productoId"),
                                    productoCodigo = GetString(reader, "productoCodigo"),
                                    productoDescripcion = GetString(reader, "productoDescripcion"),
                                    CantidadMinima = GetDecimal(reader, "CantidadMinima"),
                                    CantidadMaxima = GetDecimal(reader, "CantidadMaxima"),
                                    ConfigToleranciaNotificacion = GetDecimal(reader, "ConfigToleranciaNotificacion"),
                                    SaldoReal = GetDecimal(reader, "SaldoReal"),
                                    SaldoComprometido = GetDecimal(reader, "SaldoComprometido"),
                                    CantidadSugeridaReponer = GetDecimal(reader, "CantidadSugeridaReponer"),
                                    reabastecimientoSolicitudId = GetInt(reader, "ReabastecimientoSolicitudId"),
                                    Estado = GetString(reader, "Estado")

                                });
                            }
                        }
                    }

                    return resultado;
                }
                catch (Exception ex)
                {
                    // Mismo mecanismo de logging que usan los DAL del proyecto.
                    LogEvent log = new LogEvent();
                    log.LogWrite(ex.Message);
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public DataSet ObtenerSaldoSugeridoByProductoId(int productoId, long instalacionId)
        {
            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[sp_GET_ReabastecimientoSaldoSugeridoByProductoId]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@productoId", productoId);
                        command.Parameters.AddWithValue("@instalacionId", instalacionId);
                        command.CommandTimeout = 0;

                        var adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataSet);
                    }

                    return dataSet;
                }
                catch (Exception ex)
                {
                    // Mismo mecanismo de logging que usan los DAL del proyecto.
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

        public DataSet ObtenerUbicacionesPorReabastecerByProductoId(int productoId, long instalacionId)
        {
            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[sp_GET_ubicacionesPorReabastecerByProductoId]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@productoId", productoId);
                        command.Parameters.AddWithValue("@instalacionId", instalacionId);
                        command.CommandTimeout = 0;

                        var adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataSet);
                    }

                    return dataSet;
                }
                catch (Exception ex)
                {
                    // Mismo mecanismo de logging que usan los DAL del proyecto.
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

        private static int GetInt(SqlDataReader reader, string columna)
        {
            int ordinal = reader.GetOrdinal(columna);
            return reader.IsDBNull(ordinal) ? 0 : Convert.ToInt32(reader.GetValue(ordinal));
        }

        private static decimal GetDecimal(SqlDataReader reader, string columna)
        {
            int ordinal = reader.GetOrdinal(columna);
            return reader.IsDBNull(ordinal) ? 0m : Convert.ToDecimal(reader.GetValue(ordinal));
        }

        private static string GetString(SqlDataReader reader, string columna)
        {
            int ordinal = reader.GetOrdinal(columna);
            return reader.IsDBNull(ordinal) ? null : reader.GetValue(ordinal).ToString();
        }
    }
}
