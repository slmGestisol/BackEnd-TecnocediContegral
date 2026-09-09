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

namespace com.ServiBarras.Infrastructure.DataAccess.UbicacionLista
{
    /// <summary>
    /// Parametrización de ubicaciones contra UbicacionesListas /
    /// UbicacionesListasDetalle. Los cuatro procedimientos replican el cuerpo
    /// de SP_CargaJSONConfiguracionTipoUbicacionWizard cambiando la entrada:
    /// en vez de un JSON por módulo y columna, la lista de ubicacionId
    /// seleccionada en pantalla.
    /// </summary>
    public class UbicacionListaDAL : IUbicacionListaDAL
    {
        public TecnoCEDI_bdContext dbcontext;

        public UbicacionListaDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }

        /// <summary>
        /// Valores existentes por segmento para poblar los ocho multi-select.
        /// Cada segmento se cuenta aplicando los otros siete filtros, para que
        /// escoger un valor no vacíe su propia lista.
        /// </summary>
        public async Task<IReadOnlyList<UbicacionListaSegmentoDTO>> ObtenerSegmentosAsync(UbicacionListaFiltroDTO filtro)
        {
            var segmentos = new List<UbicacionListaSegmentoDTO>();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                try
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("[dbo].[SP_GET_UbicacionesListasSegmentos]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 0;
                        AgregarFiltrosSegmento(command, filtro);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                segmentos.Add(new UbicacionListaSegmentoDTO
                                {
                                    segmento = LeerTexto(reader, "segmento"),
                                    valor = LeerTexto(reader, "valor"),
                                    ubicaciones = LeerEntero(reader, "ubicaciones")
                                });
                            }
                        }
                    }

                    return segmentos;
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
        }

        /// <summary>
        /// Listas de UbicacionesListas para los checks de la pantalla, con
        /// cuántas ubicaciones tiene cada una hoy.
        /// </summary>
        public async Task<IReadOnlyList<UbicacionListaCatalogoDTO>> ObtenerCatalogoAsync()
        {
            var catalogo = new List<UbicacionListaCatalogoDTO>();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                try
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("[dbo].[SP_GET_UbicacionesListasCatalogo]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 0;

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                catalogo.Add(new UbicacionListaCatalogoDTO
                                {
                                    ubicacionListaId = LeerEntero(reader, "ubicacionListaId"),
                                    ubicacionListaCodigo = LeerTexto(reader, "ubicacionListaCodigo"),
                                    ubicacionListaNombre = LeerTexto(reader, "ubicacionListaNombre"),
                                    ubicacionListaAyuda = LeerTexto(reader, "ubicacionListaAyuda"),
                                    ubicaciones = LeerEntero(reader, "ubicaciones")
                                });
                            }
                        }
                    }

                    return catalogo;
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
        }

        /// <summary>
        /// Tipos de ubicación activos para el combo de la pantalla.
        /// Sale directo de la tabla; no necesita procedimiento.
        /// </summary>
        public async Task<IReadOnlyList<TiposUbicaciones>> ObtenerTiposUbicacionAsync()
        {
            try
            {
                return await dbcontext.TiposUbicaciones
                    .Where(x => x.tipoUbicacionEstado == 1)
                    .OrderBy(x => x.tipoUbicacionCodigo)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                LogEvent log = new LogEvent();
                log.LogWrite(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Grid de la pantalla: ubicaciones filtradas con su tipo, sus listas
        /// actuales y su situación de saldo.
        /// </summary>
        public async Task<IReadOnlyList<UbicacionListaConsultaDTO>> ConsultarUbicacionesAsync(UbicacionListaFiltroDTO filtro)
        {
            var ubicaciones = new List<UbicacionListaConsultaDTO>();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                try
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("[dbo].[SP_GET_UbicacionesListasConsulta]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 0;
                        AgregarFiltrosSegmento(command, filtro);

                        command.Parameters.AddWithValue("@ubicacionCodigo",
                            string.IsNullOrWhiteSpace(filtro.ubicacionCodigo) ? (object)DBNull.Value : filtro.ubicacionCodigo);
                        command.Parameters.AddWithValue("@tipoUbicacionId",
                            filtro.tipoUbicacionId.HasValue ? (object)filtro.tipoUbicacionId.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@ubicacionListaId",
                            filtro.ubicacionListaId.HasValue ? (object)filtro.ubicacionListaId.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@tieneSaldo",
                            filtro.tieneSaldo.HasValue ? (object)filtro.tieneSaldo.Value : DBNull.Value);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                ubicaciones.Add(new UbicacionListaConsultaDTO
                                {
                                    ubicacionId = LeerLargo(reader, "ubicacionId"),
                                    ubicacionCodigo = LeerTexto(reader, "ubicacionCodigo"),
                                    b = LeerTexto(reader, "b"),
                                    a = LeerTexto(reader, "a"),
                                    c = LeerTexto(reader, "c"),
                                    m = LeerTexto(reader, "m"),
                                    n = LeerTexto(reader, "n"),
                                    f = LeerTexto(reader, "f"),
                                    k = LeerTexto(reader, "k"),
                                    p = LeerTexto(reader, "p"),
                                    tipoUbicacionId = LeerLargoNulo(reader, "tipoUbicacionId"),
                                    tipoUbicacionCodigo = LeerTexto(reader, "tipoUbicacionCodigo"),
                                    listas = LeerTexto(reader, "listas"),
                                    manejaParciales = LeerBooleano(reader, "manejaParciales"),
                                    tieneSaldo = LeerBooleano(reader, "tieneSaldo"),
                                    bodegasLogicasSaldo = LeerTexto(reader, "bodegasLogicasSaldo")
                                });
                            }
                        }
                    }

                    return ubicaciones;
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
        }

        /// <summary>
        /// Aplica el tipo de ubicación y asigna las listas marcadas.
        /// El procedimiento rechaza la operación completa si alguna ubicación
        /// tiene saldo y cambiaría de tipo; ese motivo llega en @Resultado.
        /// </summary>
        public async Task<UbicacionListaRespuestaDTO> AsignarListasAsync(UbicacionListaAsignacionDTO asignacion)
        {
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                try
                {
                    await connection.OpenAsync();

                    var tablaUbicaciones = new DataTable();
                    tablaUbicaciones.Columns.Add("ubicacionId", typeof(long));

                    foreach (var ubicacionId in asignacion.ubicaciones.Distinct())
                    {
                        tablaUbicaciones.Rows.Add(ubicacionId);
                    }

                    using (var command = new SqlCommand("[dbo].[SP_SET_UbicacionesListasDetalle]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 0;

                        var parametroUbicaciones = command.Parameters.AddWithValue("@Ubicaciones", tablaUbicaciones);
                        parametroUbicaciones.SqlDbType = SqlDbType.Structured;
                        parametroUbicaciones.TypeName = "dbo.UbicacionesListasDetalleType";

                        command.Parameters.AddWithValue("@ubicacionListaIds",
                            string.Join(",", asignacion.ubicacionListaIds.Distinct()));
                        command.Parameters.AddWithValue("@tipoUbicacionCodigo", asignacion.tipoUbicacionCodigo);
                        command.Parameters.AddWithValue("@usuarioId", asignacion.usuarioId);

                        var resultado = new SqlParameter("@Resultado", SqlDbType.NVarChar, -1)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(resultado);

                        await command.ExecuteNonQueryAsync();

                        string mensaje = resultado.Value?.ToString() ?? string.Empty;

                        return new UbicacionListaRespuestaDTO
                        {
                            // El procedimiento antepone "Error:" a todo rechazo.
                            exitoso = !mensaje.StartsWith("Error", StringComparison.OrdinalIgnoreCase)
                                   && !mensaje.StartsWith("Se ha generado un error", StringComparison.OrdinalIgnoreCase),
                            mensaje = mensaje
                        };
                    }
                }
                catch (Exception ex)
                {
                    LogEvent log = new LogEvent();
                    log.LogWrite(ex.Message);
                    return new UbicacionListaRespuestaDTO
                    {
                        exitoso = false,
                        mensaje = "Error al aplicar la parametrización: " + ex.Message
                    };
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        // ── Apoyo ────────────────────────────────────────────────────────────

        /// <summary>
        /// Los ocho segmentos van como CSV; null significa "todos".
        /// </summary>
        private static void AgregarFiltrosSegmento(SqlCommand command, UbicacionListaFiltroDTO filtro)
        {
            command.Parameters.AddWithValue("@instalacionId",
                filtro.instalacionId.HasValue ? (object)filtro.instalacionId.Value : DBNull.Value);

            command.Parameters.AddWithValue("@b", ValorSegmento(filtro.b));
            command.Parameters.AddWithValue("@a", ValorSegmento(filtro.a));
            command.Parameters.AddWithValue("@c", ValorSegmento(filtro.c));
            command.Parameters.AddWithValue("@m", ValorSegmento(filtro.m));
            command.Parameters.AddWithValue("@n", ValorSegmento(filtro.n));
            command.Parameters.AddWithValue("@f", ValorSegmento(filtro.f));
            command.Parameters.AddWithValue("@k", ValorSegmento(filtro.k));
            command.Parameters.AddWithValue("@p", ValorSegmento(filtro.p));
        }

        private static object ValorSegmento(string valor)
        {
            return string.IsNullOrWhiteSpace(valor) ? (object)DBNull.Value : valor;
        }

        private static string LeerTexto(IDataRecord reader, string columna)
        {
            int indice = reader.GetOrdinal(columna);
            return reader.IsDBNull(indice) ? null : reader.GetValue(indice).ToString();
        }

        private static int LeerEntero(IDataRecord reader, string columna)
        {
            int indice = reader.GetOrdinal(columna);
            return reader.IsDBNull(indice) ? 0 : Convert.ToInt32(reader.GetValue(indice));
        }

        private static long LeerLargo(IDataRecord reader, string columna)
        {
            int indice = reader.GetOrdinal(columna);
            return reader.IsDBNull(indice) ? 0 : Convert.ToInt64(reader.GetValue(indice));
        }

        private static long? LeerLargoNulo(IDataRecord reader, string columna)
        {
            int indice = reader.GetOrdinal(columna);
            return reader.IsDBNull(indice) ? (long?)null : Convert.ToInt64(reader.GetValue(indice));
        }

        private static bool LeerBooleano(IDataRecord reader, string columna)
        {
            int indice = reader.GetOrdinal(columna);
            return !reader.IsDBNull(indice) && Convert.ToBoolean(reader.GetValue(indice));
        }
    }
}
