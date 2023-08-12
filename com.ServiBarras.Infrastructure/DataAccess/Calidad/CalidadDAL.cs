using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.LogEvent;
using com.ServiBarras.Shared.ModelDTO;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class CalidadDAL : ICalidadDAL
    {
        public TecnoCEDI_bdContext dbcontext;
        /// <summary>
        /// Constructor, geneta una instancia del contexto de la base de datos
        /// </summary>
        public CalidadDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }

        public DataSet GetCalidadSaldosUbicaciones()
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_CalidadSaldosUbicaciones]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
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

        public DataSet SetCalidadUbicaciones(CalidadDTO calidadAux)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_SET_CalidadUbicaciones]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ubicaciones", calidadAux.ubicaciones);
                        command.Parameters.AddWithValue("@novedadId", (calidadAux.novedadId == null) ? 0 : calidadAux.novedadId);
                        command.Parameters.AddWithValue("@usuarioId", calidadAux.usuarioId);
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
