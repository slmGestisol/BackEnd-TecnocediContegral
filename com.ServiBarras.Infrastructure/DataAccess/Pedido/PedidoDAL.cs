using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.LogEvent;
using com.ServiBarras.Shared.ModelDTO;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class PedidoDAL : IPedidoDAL
    {
        public TecnoCEDI_bdContext dbcontext;
        /// <summary>
        /// Constructor, genera una instancia del contexto de la base de datos
        /// </summary>
        public PedidoDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }
       
        public DataSet GetPedidos(long instalacionId)
        {


            //dbcontext.Pedidos.
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_GET_Pedidos]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@instalacionId", instalacionId);

                        command.CommandTimeout = 0;

                        var adapter = new SqlDataAdapter(command);

                        adapter.Fill(dataSet);

                    }



                }
                catch (System.Exception ex)
                {
                    LogEvent log = new LogEvent();
                    log.LogWrite(ex.Message);


                }
                finally
                {
                    connection.Close();
                }

            }

            return dataSet;
        }

        /// <summary>
        /// Método que consulta una Pedido según el PedidoId
        /// </summary>
        /// <param name="PedidoId"></param>
        /// <returns></returns>
        public async Task<Pedidos> GetPedidoAsync(long PedidoId)
        {
            var Pedido = await dbcontext.Pedidos.FindAsync(PedidoId);
            return Pedido;
        }



        public DataSet GetPedidoDetalle(long pedidoId)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_GET_PedidoDetalle]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@pedidoId", pedidoId);
                        command.CommandTimeout = 0;

                        var adapter = new SqlDataAdapter(command);

                        adapter.Fill(dataSet);

                    }



                }
                catch (System.Exception ex)
                {
                    LogEvent log = new LogEvent();
                    log.LogWrite(ex.Message);


                }
                finally
                {
                    connection.Close();
                }

            }
            return dataSet;
        }

     

        public bool ActualizarPedidoEstado(PedidoDTO pedido)
        {
            try
            {
                if (PedidoIdExists(pedido.pedidoId))
                {
                    var pedidoAux = dbcontext.Pedidos.Where(x => x.pedidoId == pedido.pedidoId && x.pedidoEstado == 0).FirstOrDefault();
                    if (pedidoAux == null) return false;

                    pedidoAux.pedidoEstado = pedido.pedidoEstado;
                    dbcontext.Entry(pedidoAux).State = EntityState.Modified;
                    dbcontext.SaveChanges();
                    return true;
                }
                else
                    return false;

            }
            catch (System.Exception ex)
            {
                LogEvent log = new LogEvent();
                log.LogWrite(ex.Message);

                return false;
            }
           
        }


        public bool SetCargarPedidos()
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_SET_CargarPedidos]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.CommandTimeout = 0;

                        command.ExecuteNonQuery();

                        return true;

                    }



                }
                catch (System.Exception ex)
                {
                    LogEvent log = new LogEvent();
                    log.LogWrite(ex.Message);
                    return false;

                }
                finally
                {
                    connection.Close();
                }

            }

        }
        public bool PedidoIdExists(long? PedidoId)
        {
            return dbcontext.Pedidos.Any(e => e.pedidoId == PedidoId);
        }
    }
}