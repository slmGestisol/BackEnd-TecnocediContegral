using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.LogEvent;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class EstacionDAL : IEstacionDAL
    {
        public TecnoCEDI_bdContext dbcontext;
        /// <summary>
        /// Constructor, genera una instancia del contexto de la base de datos
        /// </summary>
        public EstacionDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }

        public DataSet GetEstaciones(string tipoEstacionCodigo)
        {
            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_Estaciones]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@tipoEstacionCodigo", tipoEstacionCodigo);
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

        public DataSet GetUbicacionesByEstacionId(long estacionId)
        {
            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_UbicacionesByEstacionId]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@estacionId", estacionId);
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
