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
    public class RFIDDAL : IRFIDDAL
    {
        public TecnoCEDI_bdContext dbcontext;
        /// <summary>
        /// Constructor, se genera una instancia del contexto de la base de datos
        /// </summary>
        public RFIDDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }

        public DataSet GetPortalRFIDContenedores(long idPortal,long despachoConsecutivo,string inicioCaptura)
        {

            if (idPortal == 0) return null;

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[sp_GET_RFIDPortalContenedores]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@idPortal", idPortal);
                        command.Parameters.AddWithValue("@despachoConsecutivo", despachoConsecutivo);
                        command.Parameters.AddWithValue("@inicioCapturaFecha", inicioCaptura);
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