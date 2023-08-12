using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
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
    }
}
