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

namespace com.ServiBarras.Infrastructure.DataAccess.BodegaLogica
{
    public class BodegaLogicaDAL : IBodegaLogicaDAL
    {
        public TecnoCEDI_bdContext dbcontext;
        /// <summary>
        /// Constructor, geneta una instancia del contexto de la base de datos
        /// </summary>
        public BodegaLogicaDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }

        public DataSet getBodegasLogicasByProcesoNombre(string procesoNombre)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[sp_GET_BodegasLogicasByProcesoNombre]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@procesoNombre", procesoNombre);
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
