using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.LogEvent;
using com.ServiBarras.Shared.ModelDTO;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class LoteDAL : ILoteDAL
    {



        public TecnoCEDI_bdContext dbcontext;
        /// <summary>
        /// Constructor, genera una instancia del contexto de la base de datos
        /// </summary>
        public LoteDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }


        public DataSet GetLoteByLoteCodigo(string loteCodigo, long productoId)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {

                    using (var command = new SqlCommand("[dbo].[sp_GET_LoteByLoteCodigo]", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@LoteCodigo", loteCodigo);
                        command.Parameters.AddWithValue("@productoId", productoId);
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
