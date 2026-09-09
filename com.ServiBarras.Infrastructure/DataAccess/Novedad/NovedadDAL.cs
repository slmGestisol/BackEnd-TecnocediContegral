using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.ModelDTO;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.LogEvent;
using Microsoft.EntityFrameworkCore;


namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class NovedadDAL : INovedadDAL
    {

        public TecnoCEDI_bdContext dbcontext;
        /// <summary>
        /// Constructor, genera una instancia del contexto de la base de datos
        /// </summary>
        public NovedadDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();

        }

        public async Task<List<NovedadesAcciones>> GetNovedadAccionesAsync()
        {
            return await dbcontext.NovedadesAcciones.ToListAsync();
        }

        /// <summary>
        /// Método que consulta las Pedidos
        /// </summary>
        /// <returns></returns>
        public async Task<List<Novedades>> GetNovedadAsync(long novedadId)
        {
            return await dbcontext.Novedades.Where(x => x.novedadId == novedadId).ToListAsync();
        }

        public async Task<List<Novedades>> GetNovedadesbyProcesoId(int procesoId)
        {
            return await dbcontext.Novedades.Where(x => x.procesoId == procesoId).ToListAsync();
        }

        public DataSet GetNovedadByNovedadCodigo(string novedadCodigo)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_NovedadByNovedadCodigo]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@novedadCodigo", novedadCodigo);
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

        public async Task<IReadOnlyList<NovedadItemDto>> ObtenerNovedadesAsync(int? procesoId, bool incluirInactivas)
        {
            string connectionString = dbcontext.Database.GetDbConnection().ConnectionString;

            var resultado = new List<NovedadItemDto>();

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                try
                {
                    using (var command = new SqlCommand("[dbo].[sp_GET_novedades]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 0;

                        command.Parameters.AddWithValue("@procesoId",
                            procesoId.HasValue ? (object)procesoId.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@incluirInactivas", incluirInactivas);

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                resultado.Add(new NovedadItemDto
                                {
                                    novedadId = GetInt(reader, "novedadId"),
                                    novedadCodigo = GetString(reader, "novedadCodigo"),
                                    novedadNombre = GetString(reader, "novedadNombre"),
                                    novedadDescripcion = GetString(reader, "novedadDescripcion"),
                                    procesoId = GetInt(reader, "procesoId"),
                                    procesoNombre = GetString(reader, "procesoNombre"),
                                    novedadActivo = GetBool(reader, "novedadActivo"),
                                    novedadFechaModificacion = GetNullableDateTime(reader, "novedadFechaModificacion"),
                                    novedadUsuarioIdModificacion = GetNullableInt(reader, "novedadUsuarioIdModificacion")
                                });
                            }
                        }
                    }

                    return resultado;
                }
                catch (Exception ex)
                {
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

        public async Task<NovedadResultDto> GuardarNovedadAsync(GuardarNovedadRequestDto request)
        {
            string connectionString = dbcontext.Database.GetDbConnection().ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                try
                {
                    using (var command = new SqlCommand("[dbo].[sp_SET_GuardarNovedades]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 0;

                        // El SP trata 0 / NULL como creación
                        command.Parameters.AddWithValue("@novedadId",
                            request.novedadId.HasValue ? (object)request.novedadId.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@novedadCodigo",
                            (object)request.novedadCodigo ?? DBNull.Value);
                        command.Parameters.AddWithValue("@novedadNombre",
                            (object)request.novedadNombre ?? DBNull.Value);
                        command.Parameters.AddWithValue("@novedadDescripcion",
                            (object)request.novedadDescripcion ?? DBNull.Value);
                        command.Parameters.AddWithValue("@procesoId", request.procesoId);
                        command.Parameters.AddWithValue("@usuarioId", request.usuarioId);

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new NovedadResultDto
                                {
                                    exitoso = GetBool(reader, "exitoso"),
                                    mensaje = GetString(reader, "mensaje"),
                                    novedadId = GetNullableInt(reader, "novedadId")
                                };
                            }
                        }
                    }

                    // El SP siempre devuelve un result set; si no llegó, se trata como error.
                    return new NovedadResultDto
                    {
                        exitoso = false,
                        mensaje = "El procedimiento no devolvió resultado"
                    };
                }
                catch (Exception ex)
                {
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

        public async Task<NovedadResultDto> CambiarEstadoNovedadAsync(int novedadId, bool activo, int usuarioId)
        {
            string connectionString = dbcontext.Database.GetDbConnection().ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                try
                {
                    using (var command = new SqlCommand("[dbo].[sp_SET_Novedades_CambiarEstado]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 0;

                        command.Parameters.AddWithValue("@novedadId", novedadId);
                        command.Parameters.AddWithValue("@activo", activo);
                        command.Parameters.AddWithValue("@usuarioId", usuarioId);

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new NovedadResultDto
                                {
                                    exitoso = GetBool(reader, "exitoso"),
                                    mensaje = GetString(reader, "mensaje"),
                                    novedadId = GetNullableInt(reader, "novedadId")
                                };
                            }
                        }
                    }

                    return new NovedadResultDto
                    {
                        exitoso = false,
                        mensaje = "El procedimiento no devolvió resultado"
                    };
                }
                catch (Exception ex)
                {
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

        private static int GetInt(SqlDataReader reader, string columna)
        {
            int ordinal = reader.GetOrdinal(columna);
            return reader.IsDBNull(ordinal) ? 0 : Convert.ToInt32(reader.GetValue(ordinal));
        }

        private static int? GetNullableInt(SqlDataReader reader, string columna)
        {
            int ordinal = reader.GetOrdinal(columna);
            return reader.IsDBNull(ordinal) ? (int?)null : Convert.ToInt32(reader.GetValue(ordinal));
        }

        private static bool GetBool(SqlDataReader reader, string columna)
        {
            int ordinal = reader.GetOrdinal(columna);
            return !reader.IsDBNull(ordinal) && Convert.ToBoolean(reader.GetValue(ordinal));
        }

        private static DateTime? GetNullableDateTime(SqlDataReader reader, string columna)
        {
            int ordinal = reader.GetOrdinal(columna);
            return reader.IsDBNull(ordinal) ? (DateTime?)null : Convert.ToDateTime(reader.GetValue(ordinal));
        }

        private static string GetString(SqlDataReader reader, string columna)
        {
            int ordinal = reader.GetOrdinal(columna);
            return reader.IsDBNull(ordinal) ? null : reader.GetValue(ordinal).ToString();
        }
    }
}
