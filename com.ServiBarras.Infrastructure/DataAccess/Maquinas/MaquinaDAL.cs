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
    public class MaquinaDAL : IMaquinaDAL
    {



        public TecnoCEDI_bdContext dbcontext;
        /// <summary>
        /// Constructor, genera una instancia del contexto de la base de datos
        /// </summary>
        public MaquinaDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }


        public async Task<List<Models.Maquinas>> GetMaquinasAsync()
        {
           return await dbcontext.Maquinas.Where(x=>x.maquinaEstado == 0).ToListAsync();
           
        }


        public DataSet AsignarMaquinaUsuario(MaquinaDTO maquina)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_SET_CambiarUsuarioTagRIFD]", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@maquinaId", maquina.maquinaId);
                        command.Parameters.AddWithValue("@usuarioId", maquina.usuarioId);
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
