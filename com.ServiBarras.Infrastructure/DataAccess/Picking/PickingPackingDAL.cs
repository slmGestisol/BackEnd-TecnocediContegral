using System.Data;
using System.Data.SqlClient;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.LogEvent;
using com.ServiBarras.Shared.ModelDTO;
using Microsoft.EntityFrameworkCore;
using com.ServiBarras.Shared.SqlData;
using System.Collections.Generic;
using com.ServiBarras.Shared.Utils;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class PickingPackingDAL : IPickingPackingDAL
    {
        public TecnoCEDI_bdContext dbcontext;
        /// <summary>
        /// Constructor, genera una instancia del contexto de la base de datos
        /// </summary>
        public PickingPackingDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }

        public DataSet SetPickingPackingRuteo(List<PickingPackingDTO> pickingPackingDTO)
        {
          
            if (pickingPackingDTO == null) return null;



            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    SqlObjectData SqlObjectData = new SqlObjectData();
                    //onverterObject converterObject = new ConverterObject();

                    foreach (var pedido in pickingPackingDTO)
                    {
                        
                    }

                    dbcontext.SaveChanges();

                    DataTable pedidosSeleccionados = ConverterObject.CreateDataTable(pickingPackingDTO);
                    SqlObjectData.BulkInsertDataTable("PedidosPreRuteo", pedidosSeleccionados, dbcontext.Database.GetDbConnection().ConnectionString);

                    using (var command = new SqlCommand("[dbo].[SP_SET_PickingRuteo]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                       // command.Parameters.AddWithValue("@ruteoId", pickingPackingDTO.ruteoId);
                        //command.Parameters.AddWithValue("@productoId", pickingDTO.productoId);
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
