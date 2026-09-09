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
using Newtonsoft.Json;

namespace com.ServiBarras.Infrastructure.DataAccess.ConfigReabastecimiento
{
    /// <summary>
    /// Acceso a datos de la parametrización de reabastecimiento
    /// (ConfigReabastecimientoProducto / ConfigReabastecimientoUbicacion),
    /// con la misma forma de acceso del resto del proyecto: ADO.NET sobre la
    /// cadena de conexión que expone TecnoCEDI_bdContext (ver ReabastecimientoDAL).
    /// </summary>
    public class ConfigReabastecimientoDAL : IConfigReabastecimientoDAL
    {
        public TecnoCEDI_bdContext dbcontext;

        public ConfigReabastecimientoDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }

        public async Task<IReadOnlyList<ConfigReabastecimientoItemDto>> ObtenerConfiguracionesAsync()
        {
            string connectionString = dbcontext.Database.GetDbConnection().ConnectionString;

            var resultado = new List<ConfigReabastecimientoItemDto>();

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_ConfigReabastecimiento]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 0;

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                resultado.Add(new ConfigReabastecimientoItemDto
                                {
                                    configReabastecimientoProductoId = GetLong(reader, "configReabastecimientoProductoId"),
                                    productoId = GetLong(reader, "productoId"),
                                    productoCodigo = GetString(reader, "productoCodigo"),
                                    productoDescripcion = GetString(reader, "productoDescripcion"),
                                    cantidadMinima = GetDecimal(reader, "cantidadMinima"),
                                    cantidadMaxima = GetDecimal(reader, "cantidadMaxima"),
                                    configToleranciaNotificacion = GetDecimal(reader, "configToleranciaNotificacion"),
                                    totalUbicaciones = GetInt(reader, "totalUbicaciones"),
                                    fechaCreacion = GetDateTime(reader, "fechaCreacion")
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

        public async Task<ConfigReabastecimientoDetalleDto> ObtenerDetalleAsync(long configReabastecimientoProductoId)
        {
            string connectionString = dbcontext.Database.GetDbConnection().ConnectionString;

            ConfigReabastecimientoDetalleDto resultado = null;

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_ConfigReabastecimientoDetalle]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@configReabastecimientoProductoId", configReabastecimientoProductoId);
                        command.CommandTimeout = 0;

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            // Result set 1: maestro (vacío si no existe o está inactiva)
                            if (await reader.ReadAsync())
                            {
                                resultado = new ConfigReabastecimientoDetalleDto
                                {
                                    configReabastecimientoProductoId = GetLong(reader, "configReabastecimientoProductoId"),
                                    productoId = GetLong(reader, "productoId"),
                                    productoCodigo = GetString(reader, "productoCodigo"),
                                    productoDescripcion = GetString(reader, "productoDescripcion"),
                                    cantidadMinima = GetDecimal(reader, "cantidadMinima"),
                                    cantidadMaxima = GetDecimal(reader, "cantidadMaxima"),
                                    configToleranciaNotificacion = GetDecimal(reader, "configToleranciaNotificacion")
                                };
                            }

                            // Result set 2: ubicaciones activas ordenadas por orden
                            if (resultado != null && await reader.NextResultAsync())
                            {
                                while (await reader.ReadAsync())
                                {
                                    resultado.ubicaciones.Add(new ConfigReabastecimientoUbicacionDto
                                    {
                                        configReabastecimientoUbicacionId = GetLong(reader, "configReabastecimientoUbicacionId"),
                                        ubicacionId = GetLong(reader, "ubicacionId"),
                                        ubicacionCodigo = GetString(reader, "ubicacionCodigo"),
                                        orden = GetInt(reader, "orden")
                                    });
                                }
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

        public async Task<IReadOnlyList<ProductoSinConfigReabastecimientoDto>> ObtenerProductosSinConfigAsync()
        {
            string connectionString = dbcontext.Database.GetDbConnection().ConnectionString;

            var resultado = new List<ProductoSinConfigReabastecimientoDto>();

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_ProductosSinConfigReabastecimiento]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 0;

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                resultado.Add(new ProductoSinConfigReabastecimientoDto
                                {
                                    productoId = GetLong(reader, "productoId"),
                                    productoCodigo = GetString(reader, "productoCodigo"),
                                    productoDescripcion = GetString(reader, "productoDescripcion")
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

        public async Task<IReadOnlyList<UbicacionReabastecimientoDto>> ObtenerUbicacionesElegiblesAsync()
        {
            string connectionString = dbcontext.Database.GetDbConnection().ConnectionString;

            var resultado = new List<UbicacionReabastecimientoDto>();

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_UbicacionesReabastecimiento]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 0;

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                resultado.Add(new UbicacionReabastecimientoDto
                                {
                                    ubicacionId = GetLong(reader, "ubicacionId"),
                                    ubicacionCodigo = GetString(reader, "ubicacionCodigo"),
                                    ubicacionEtiqueta = GetString(reader, "ubicacionEtiqueta"),
                                    ubicacionDescripcion = GetString(reader, "ubicacionDescripcion")
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

        public async Task<ConfigReabastecimientoResultDto> GuardarAsync(GuardarConfigReabastecimientoRequestDto request)
        {
            string connectionString = dbcontext.Database.GetDbConnection().ConnectionString;

            // El SP recibe la lista completa de ubicaciones como JSON:
            // [{"ubicacionId":6377,"orden":1},...] y renumera orden = 1..N
            // según la posición en el arreglo.
            string ubicacionesJson = JsonConvert.SerializeObject(request.ubicaciones ?? new List<GuardarConfigReabastecimientoUbicacionDto>());

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_SET_GuardarConfigReabastecimiento]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 0;

                        command.Parameters.AddWithValue("@configReabastecimientoProductoId",
                            request.configReabastecimientoProductoId.HasValue ? (object)request.configReabastecimientoProductoId.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@productoId", request.productoId);
                        command.Parameters.AddWithValue("@cantidadMinima", request.cantidadMinima);
                        command.Parameters.AddWithValue("@cantidadMaxima", request.cantidadMaxima);
                        command.Parameters.AddWithValue("@configToleranciaNotificacion", request.configToleranciaNotificacion);
                        command.Parameters.AddWithValue("@usuarioId", request.usuarioId);
                        command.Parameters.AddWithValue("@ubicacionesJson", ubicacionesJson);

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new ConfigReabastecimientoResultDto
                                {
                                    exitoso = GetBool(reader, "exitoso"),
                                    mensaje = GetString(reader, "mensaje"),
                                    configReabastecimientoProductoId = GetNullableLong(reader, "configReabastecimientoProductoId")
                                };
                            }
                        }
                    }

                    // El SP siempre devuelve un result set; si no llegó, se trata como error.
                    return new ConfigReabastecimientoResultDto
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

        public async Task<ConfigReabastecimientoResultDto> InactivarAsync(long configReabastecimientoProductoId, long usuarioId)
        {
            string connectionString = dbcontext.Database.GetDbConnection().ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_SET_InactivarConfigReabastecimiento]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 0;

                        command.Parameters.AddWithValue("@configReabastecimientoProductoId", configReabastecimientoProductoId);
                        command.Parameters.AddWithValue("@usuarioId", usuarioId);

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new ConfigReabastecimientoResultDto
                                {
                                    exitoso = GetBool(reader, "exitoso"),
                                    mensaje = GetString(reader, "mensaje")
                                };
                            }
                        }
                    }

                    return new ConfigReabastecimientoResultDto
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

        private static long GetLong(SqlDataReader reader, string columna)
        {
            int ordinal = reader.GetOrdinal(columna);
            return reader.IsDBNull(ordinal) ? 0L : Convert.ToInt64(reader.GetValue(ordinal));
        }

        private static long? GetNullableLong(SqlDataReader reader, string columna)
        {
            int ordinal = reader.GetOrdinal(columna);
            return reader.IsDBNull(ordinal) ? (long?)null : Convert.ToInt64(reader.GetValue(ordinal));
        }

        private static decimal GetDecimal(SqlDataReader reader, string columna)
        {
            int ordinal = reader.GetOrdinal(columna);
            return reader.IsDBNull(ordinal) ? 0m : Convert.ToDecimal(reader.GetValue(ordinal));
        }

        private static bool GetBool(SqlDataReader reader, string columna)
        {
            int ordinal = reader.GetOrdinal(columna);
            return !reader.IsDBNull(ordinal) && Convert.ToBoolean(reader.GetValue(ordinal));
        }

        private static DateTime GetDateTime(SqlDataReader reader, string columna)
        {
            int ordinal = reader.GetOrdinal(columna);
            return reader.IsDBNull(ordinal) ? DateTime.MinValue : Convert.ToDateTime(reader.GetValue(ordinal));
        }

        private static string GetString(SqlDataReader reader, string columna)
        {
            int ordinal = reader.GetOrdinal(columna);
            return reader.IsDBNull(ordinal) ? null : reader.GetValue(ordinal).ToString();
        }
    }
}
