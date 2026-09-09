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
    public class ProcesoDAL : IProcesoDAL
    {
        public TecnoCEDI_bdContext dbcontext;
        /// <summary>
        /// Constructor, genera una instancia del contexto de la base de datos
        /// </summary>
        public ProcesoDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();

        }

        public async Task<IReadOnlyList<ProcesoComboDto>> ObtenerProcesosAsync()
        {
            string connectionString = dbcontext.Database.GetDbConnection().ConnectionString;

            var resultado = new List<ProcesoComboDto>();

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                try
                {
                    using (var command = new SqlCommand("[dbo].[sp_GET_Procesos]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 0;

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                resultado.Add(new ProcesoComboDto
                                {
                                    procesoId = GetInt(reader, "ProcesoId"),
                                    procesoCodigo = GetString(reader, "ProcesoCodigo"),
                                    procesoNombre = GetString(reader, "ProcesoNombre")
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

        private static int GetInt(SqlDataReader reader, string columna)
        {
            int ordinal = reader.GetOrdinal(columna);
            return reader.IsDBNull(ordinal) ? 0 : Convert.ToInt32(reader.GetValue(ordinal));
        }

        private static string GetString(SqlDataReader reader, string columna)
        {
            int ordinal = reader.GetOrdinal(columna);
            return reader.IsDBNull(ordinal) ? null : reader.GetValue(ordinal).ToString();
        }

        public List<NovedadDto> GetNovedadesByNameProceso(string nombreProceso)
        {
            Procesos procesoItem = dbcontext.Procesos
                .Where(x => x.ProcesoNombre == nombreProceso)
                .FirstOrDefault();

            if (procesoItem == null)
            {
                return null;
            }

            List<NovedadDto> novedadesItems = dbcontext.Novedades
                .Where(x => x.procesoId == procesoItem.ProcesoId && x.novedadActivo == true)
                .Select(x => new NovedadDto
                {
                    novedadId = x.novedadId,
                    novedadDescripcion = x.novedadDescripcion,
                    novedadCodigo = x.novedadCodigo,
                    novedadNombre = x.novedadNombre,
                    novedadAfectaSaldo = x.novedadAfectaSaldo
                })
                .ToList();

            if (nombreProceso.ToUpper() == "CALIDAD")
            {
                NovedadDto novedadItem = dbcontext.Novedades
                    .Where(x => x.novedadCodigo == "000" && x.novedadActivo == true)
                    .Select(x => new NovedadDto
                    {
                        novedadId = x.novedadId,
                        novedadDescripcion = x.novedadDescripcion,
                        novedadCodigo = x.novedadCodigo,
                        novedadNombre = x.novedadNombre,
                        novedadAfectaSaldo = x.novedadAfectaSaldo
                    })
                    .FirstOrDefault();

                if (novedadItem != null)
                {
                    novedadesItems.Add(novedadItem);
                }
            }

            return novedadesItems;
        }
    }
}
