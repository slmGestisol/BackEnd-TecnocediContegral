
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
using com.ServiBarras.Shared.ModelDTO;
using com.ServiBarras.Shared.SqlData;
using com.ServiBarras.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class PreRuteoDAL : IPreRuteoDAL
    {
        public TecnoCEDI_bdContext dbcontext;
        /// <summary>
        /// Constructor, genera una instancia del contexto de la base de datos
        /// </summary>
        public PreRuteoDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }
        /// <summary>
        /// Método que consulta los PreRuteos
        /// </summary>
        /// <returns></returns>
        public async Task<List<PreRuteos>> GetPreRuteoAsync(long preRuteoId)
        {
            return await dbcontext.PreRuteos.Where(x => x.preRuteoPedidoEstado == 0 && x.preRuteoId == preRuteoId).ToListAsync();
        }
        public async Task<List<PreRuteos>> GetPreRuteosAsync()
        {
            return await dbcontext.PreRuteos.Where(x => x.preRuteoPedidoEstado == 0).ToListAsync();


        }

        public DataSet GetPreRuteos()
        {


            //dbcontext.Pedidos.
            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {


                    using (var command = new SqlCommand("[dbo].[SP_GET_Preruteos]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;


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






        public DataSet GetPreRuteoDetalle(long preRuteoId)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_GET_PreruteoDetalle]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@preRuteoId", preRuteoId);
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
            //return await dbcontext.PreRuteosDetalle.Where(x => x.preRuteoPedidoEstado == 0).ToListAsync();
        }

        public async Task<List<Pedidos>> GetPedidosPreRuteo(long preRuteoId)
        {
            var pedidosPreruteo = await (from preruteo in dbcontext.PreRuteosPedidos
                                         join pedido in dbcontext.Pedidos on preruteo.pedidoId equals pedido.pedidoId
                                         where preruteo.preRuteoId == preRuteoId
                                         select pedido).ToListAsync();

            return pedidosPreruteo;
        }

        public void CancelPreruteo(PreRuteoItemDTO prereRuteoAux)
        {
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_CANCEL_PreRuteo]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@preRuteoId", prereRuteoAux.preRuteoId);
                        command.CommandTimeout = 0;

                        command.ExecuteNonQuery();

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
        }




        /// <summary>
        /// Método que consulta los PreRuteos según el preRuteoId
        /// </summary>
        /// <param name="preRuteoId"></param>
        /// <returns></returns>
        ///
        public async Task<PreRuteos> GetPreRuteosAsync(long preRuteoId)
        {
            var preRuteo = await dbcontext.PreRuteos.FindAsync(preRuteoId);
            return preRuteo;
        }
        /// <summary>
        /// Método que actualiza los PreRuteos según el preRuteoId
        /// </summary>
        /// <param name="preRuteoId"></param>
        /// <param name="preRuteo"></param>
        /// <returns></returns>
        public async Task UpdatePreRuteosAsync(long preRuteoId, PreRuteos preRuteo)
        {
            if (preRuteoId != preRuteo.preRuteoId)
            {

            }

            dbcontext.Entry(preRuteo).State = EntityState.Modified;

            try
            {
                await dbcontext.SaveChangesAsync();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (DbUpdateConcurrencyException ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                if (!PreRuteosIdExists(preRuteoId))
                {

                }
                else
                {
                    throw;
                }
            }
            catch (System.Exception ex)
            {
                LogEvent log = new LogEvent();
                log.LogWrite(ex.Message);

                //return null;
            }

        }



        /// <summary>
        /// Método que insertar pedidos para preruteo en la tabla PedidosPreRuteo
        /// </summary>
        /// <param name="pedidosPreRuteolist"></param>
        public void AddPedidosPreRuteo(List<PedidosPreRuteoDTO> pedidosPreRuteolist)
        {
            try
            {
                SqlObjectData SqlObjectData = new SqlObjectData();
                //onverterObject converterObject = new ConverterObject();

                foreach (var pedido in pedidosPreRuteolist)
                {
                    var pedidoPreruteo = dbcontext.PedidosPreRuteo.Where(x => x.pedidoId == pedido.pedidoId).FirstOrDefault();
                    if (pedidoPreruteo == null) continue;
                    dbcontext.Entry(pedidoPreruteo).State = EntityState.Deleted;
                }

                dbcontext.SaveChanges();

                
                //pedidosPreRuteolist.All(x => x.Estado == false );

                foreach (var item in pedidosPreRuteolist)
                {
                    item.Estado = false;
                }

                
                //.Estado = false;// --.All(x => x.Estado = false);

                DataTable pedidosSeleccionados = ConverterObject.CreateDataTable(pedidosPreRuteolist);
                SqlObjectData.BulkInsertDataTable("PedidosPreRuteo", pedidosSeleccionados, dbcontext.Database.GetDbConnection().ConnectionString);
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (System.Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

                throw;
            }
           


            
        }



        /// <summary>
        /// Método que inserta los preRuteo en la tabla PreRuteos
        /// </summary>
        /// <param name="preRuteo"></param>
        public void AddPreRuteos(PreRuteos preRuteo)
        {
            dbcontext.PreRuteos.Add(preRuteo);
            dbcontext.SaveChangesAsync();

        }
        /// <summary>
        /// Método que elimina los PreRuteos 
        /// </summary>
        /// <param name="preRuteoId"></param>
        public void DeletePreRuteos(long preRuteoId)
        {
            var preRuteo = dbcontext.PreRuteos.Find(preRuteoId);
            if (preRuteo == null)
            {

            }

            dbcontext.PreRuteos.Remove(preRuteo);
            dbcontext.SaveChanges();


        }
        /// <summary>
        /// Método que valida si existe o no una  PreRuteo
        /// </summary>
        /// <param name="preRuteoId"></param>
        /// <returns></returns>
        public bool PreRuteosIdExists(long preRuteoId)
        {
            return dbcontext.PreRuteos.Any(e => e.preRuteoId == preRuteoId);
        }


        public DataSet SPProcessPreRuteo(PreRuteoDTO preRuteoDTO)
        {

            if (preRuteoDTO == null) return null;



            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {


                    using (var command = new SqlCommand("[dbo].[SP_SET_PreRuteo]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        //command.Parameters.AddWithValue("@cantidadinicial",  preRuteoDTO.cantidadInicial);
                        //command.Parameters.AddWithValue("@cantidadfinal", preRuteoDTO.cantidadFinal);
                        command.Parameters.AddWithValue("@usuarioId", preRuteoDTO.usuarioId);
                        command.Parameters.AddWithValue("@uniqueProcessId", preRuteoDTO.uniqueProcessId);
                        command.Parameters.AddWithValue("@instalacionId", preRuteoDTO.instalacionId);
                        command.Parameters.AddWithValue("@SoloEstibasCompletas", preRuteoDTO.SoloEstibasCompletas);


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
        private string sqlDatoToJson(SqlDataReader dataReader)
        {
            var dataTable = new DataTable();
            dataTable.Load(dataReader);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(dataTable);
            return JSONString;
        }


        public DataSet GetPreRuteoNovedades(long preRuteoId)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_PreruteoNovedades]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@preRuteoId", preRuteoId);
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


        public DataSet SetPreruteoCrossDocking(PreRuteoNovedadesDTO preRuteoDTO)
        {

            if (preRuteoDTO == null) return null;

            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_SET_PreruteoCrossDocking]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;                        
                        command.Parameters.AddWithValue("@preRuteoId", preRuteoDTO.preRuteoId);
                        command.Parameters.AddWithValue("@preRuteoDetalleId", preRuteoDTO.preRuteoDetalleId);
                        command.Parameters.AddWithValue("@esCrossDocking", preRuteoDTO.esCrossDocking);
                        command.Parameters.AddWithValue("@usuarioId", preRuteoDTO.usuarioId);
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

        public DataSet GetPedidoSecuencial()
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {

                    using (var command = new SqlCommand("[dbo].[sp_GET_pedidoSecuencial]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        //command.Parameters.AddWithValue("@preRuteoId", preRuteoId);
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
            //return await dbcontext.PreRuteosDetalle.Where(x => x.preRuteoPedidoEstado == 0).ToListAsync();
        }

        public DataSet getPedidoOrdenConfiguracion(long preRuteoId)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {

                    using (var command = new SqlCommand("[dbo].[sp_GET_pedidoOrdenConfiguracion]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@preRuteoId", preRuteoId);
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
            //return await dbcontext.PreRuteosDetalle.Where(x => x.preRuteoPedidoEstado == 0).ToListAsync();
        }

        public DataSet setPedidoConfiguracionOrden(List<PedidosConfiguracionOrdenDTO> pedidosConfiguracionOrdenDTO)
        {
            try
            {
                var dataSet = new DataSet();

                SqlObjectData SqlObjectData = new SqlObjectData();
                //onverterObject converterObject = new ConverterObject();
                dbcontext.pedidoOrden.RemoveRange(dbcontext.pedidoOrden.Where(x => x.ruteoId == pedidosConfiguracionOrdenDTO[0].ruteoId));
                dbcontext.SaveChanges();


                DataTable pedidosConfiguracionOrdenAux = ConverterObject.CreateDataTable(pedidosConfiguracionOrdenDTO);
                SqlObjectData.BulkInsertDataTable("pedidoOrden", pedidosConfiguracionOrdenAux, dbcontext.Database.GetDbConnection().ConnectionString);

                return dataSet;
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (System.Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

                throw;
            }

        }

        /// <summary>
        /// Método que insertar pedidos Detalle para exculir del preruteo en la tabla CrossDockingExcluirRuteo
        /// </summary>
        /// <param name="pedidosPreRuteolist"></param>
        public DataSet addpedidosDetalleCrossDocking(List<PedidosDetalleCrossDockingDTO> parametrosPedidosDetalleCrossDocking)
        {
            try
            {
                SqlObjectData SqlObjectData = new SqlObjectData();
                //onverterObject converterObject = new ConverterObject();


                //.Estado = false;// --.All(x => x.Estado = false);

                DataTable pedidosSeleccionados = ConverterObject.CreateDataTable(parametrosPedidosDetalleCrossDocking);
                SqlObjectData.BulkInsertDataTable("CrossDockingExcluirRuteo", pedidosSeleccionados, dbcontext.Database.GetDbConnection().ConnectionString);
                var dataSet = new DataSet();
                
                return dataSet;
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (System.Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

                throw;
            }




        }





    }


}
