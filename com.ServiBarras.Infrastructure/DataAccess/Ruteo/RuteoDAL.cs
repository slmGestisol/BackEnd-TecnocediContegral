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
using Microsoft.EntityFrameworkCore.Internal;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class RuteoDAL : IRuteoDAL
    {

        public TecnoCEDI_bdContext dbcontext;
        /// <summary>
        /// Constructor, genera una instancia del contexto de la base de datos
        /// </summary>
        public RuteoDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }
        /// <summary>
        /// Método que consulta los Ruteos
        /// </summary>
        /// <returns></returns>
        public async Task<List<Ruteos>> GetRuteosAsync()
        {
            return await dbcontext.Ruteos.Where(x => x.ruteoPedidoEstado == 0).ToListAsync();
        }

        public DataSet GetRuteosByInstalacionIdAsync(long instalacionId)
        {

            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {

                    using (var command = new SqlCommand("[dbo].[sp_GET_RuteosByInstalacion]", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@instalacionId", instalacionId);
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
            /*
                        Posts.Join(
                Post_metas,
                post => post.Post_id,
                meta => meta.Post_id,
                (post, meta) => new { Post = post, Meta = meta }
            )

                            from p in Posts
                            join pm in Post_metas on p.Post_id equals pm.Post_id
                            select new { Post = p, Meta = pm }

                             return await dbcontext.Ruteos.Join( ruteos => ruteos.ruteoId,ruteosPedidos=> ruteosPedidos.ruteoId ,(ruteos, ruteosPedidos) => new { Ruteos = ruteos, RuteosPedidos = ruteosPedidos });
            
            return await dbcontext.Ruteos.Where(x => x.ruteoPedidoEstado == 0 && x.instalacionId == instalacionId).Join(dbcontext.RuteosPedidos, x=>x.ruteoId,g=>g,(x=>x.ruteoId,g=>g.ruteoId)).ToListAsync();

            return await dbcontext.Ruteos.Where(x => x.ruteoPedidoEstado == 0 && x.instalacionId == instalacionId).ToListAsync();*/
        }

        /// <summary>
        /// Método que consulta los Ruteos pedidos
        /// </summary>
        /// <returns></returns>
        public DataSet GetRuteosPedidosBahiasbyRuteoId(long ruteoId)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_GET_RuteosPedidosBahias]", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ruteoId", ruteoId);
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


        public DataSet GetRuteosPedidosProductosbyRuteoId(long ruteoId)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_GET_RuteosPedidosProductos]", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ruteoId", ruteoId);

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


        /// <summary>
        /// Método que consulta los Ruteos según el ruteoId
        /// </summary>
        /// <param name="ruteoId"></param>
        /// <returns></returns>
        ///
        public async Task<Ruteos> GetRuteoAsync(long ruteoId)
        {
            var ruteo = await dbcontext.Ruteos.FindAsync(ruteoId);
            return ruteo;
        }

        public DataSet GetRuteoDetalle(long ruteoId, long? ruteoDetalleId)
        {
            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_GET_RuteoDetalle]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ruteoId", ruteoId);
                        command.Parameters.AddWithValue("@ruteoDetalleId", ruteoDetalleId);
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

        public void AddRuteosPedidosDetalleEstado(long ruteoId)
        {
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_Add_RuteosPedidosDetalleEstado]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        
                        command.Parameters.AddWithValue("@ruteoId", ruteoId);
                        command.CommandTimeout = 0;
                        command.ExecuteNonQuery();
                       

                        

                    }
                    return;
                }

                catch (System.Exception ex)
                {
                    LogEvent log = new LogEvent();
                    log.LogWrite(ex.Message);

                    return;
                }
                finally
                {

                    connection.Close();


                }


            }

        }

        public DataSet GetRuteoPedidosInfo(long ruteoId)
        {

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_RuteoPedidosInfo]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ruteoId", ruteoId);                       
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

        public DataSet GetRuteoDetalleFilters(RuteoDetalleDTO ruteoAux)
        {
            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_GET_RuteoDetalle_ProductoId_BahiaId]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@bahiaId", (ruteoAux.bahiaId == null) ? 0 : ruteoAux.bahiaId);
                        command.Parameters.AddWithValue("@productoId", (ruteoAux.productoId == null) ? 0 : ruteoAux.productoId);
                        command.Parameters.AddWithValue("@ruteoId", ruteoAux.ruteoId);
                        command.Parameters.AddWithValue("@bodegaLogica", (ruteoAux.bodegaLogicaId == null) ? 0 : ruteoAux.bodegaLogicaId);

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

        public DataSet GetFiltroBahiasProductosRuteo(RuteoBahiaProductoFilterDTO ruteoAux)
        {
            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_GET_FiltroBahiasProductosRuteo]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ruteoId", ruteoAux.ruteoId);
                        command.Parameters.AddWithValue("@bahiaId", (ruteoAux.bahiaId == null) ? 0 : ruteoAux.bahiaId);
                        command.Parameters.AddWithValue("@productoId", (ruteoAux.productoId == null) ? 0 : ruteoAux.productoId);
                      
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


        public async Task<RuteosDetalle> GetRuteosDetalleItemAsync(long ruteoDetalleId)
        {
            return await dbcontext.RuteosDetalle.Where(x => x.ruteoDetalleId == ruteoDetalleId).Include(y => y.presentacion).FirstOrDefaultAsync();
        }

        public DataSet SP_Add_NovedadRuteo(long novedadId, long ruteoId, long ruteoDetalleId, long usuarioId)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_ADD_NovedadRuteo]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
#pragma warning disable CS0472 // The result of the expression is always 'false' since a value of type 'long' is never equal to 'null' of type 'long?'
                        command.Parameters.AddWithValue("@novedadId", (novedadId == null) ? 0 : novedadId);
#pragma warning restore CS0472 // The result of the expression is always 'false' since a value of type 'long' is never equal to 'null' of type 'long?'
                        command.Parameters.AddWithValue("@ruteoId", ruteoId);
                        command.Parameters.AddWithValue("@ruteoDetalleId", ruteoDetalleId);
                        command.Parameters.AddWithValue("@usuarioId", usuarioId);
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

        public DataSet GetAsignacionBahiasRuteoId(int ruteoId)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_AsignacionBahiasRuteo]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ruteoId", ruteoId);

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

        public DataSet SP_Add_Ruteo(long preRuteoId, long usuarioId)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_SET_Ruteo]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@preRuteoId", preRuteoId);
                        command.Parameters.AddWithValue("@usuarioId", usuarioId);
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

        public DataSet SP_Add_RuteoDetalle(long ruteoId, long usuarioId)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_SET_RuteoDetalle]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ruteoId", ruteoId);
                        command.Parameters.AddWithValue("@usuarioId", usuarioId);
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


        public void SP_Update_RuteoGrupos(long preRuteoId, List<RuteoGrupoDTO> ruteosGrupos)
        {
            try
            {
                if (ruteosGrupos == null) return;
                if (ruteosGrupos.Count == 0) return;
                List<RuteoGrupoDTO> rutasGruposItems = new List<RuteoGrupoDTO>();


                rutasGruposItems = GetRutasByGrupoId(preRuteoId, ruteosGrupos);
                var rutasRuteoGroup = rutasGruposItems.GroupBy(x => x.rutaId);
                var ruteoDetalleItems = dbcontext.RuteosDetalle.Where(x => x.ruteoId == preRuteoId).ToListAsync();
                int cantRutas = rutasRuteoGroup.Count();

                foreach (var rutaItem in rutasRuteoGroup)
                {
                    int registrosxRuta = ruteoDetalleItems.Result.Count / cantRutas;


                    if (cantRutas == 1)
                    {
                        var rutaItems = rutaItem.ToList();
                        //int cantRuteoDetalle = registrosxRuta/ rutaItem.Count();
                        int cantidadDistribuidaGrupo = 0;
                        int cantidadRestante = 0;
                        cantidadDistribuidaGrupo = registrosxRuta / rutaItem.Count();

                        cantidadRestante = registrosxRuta - (cantidadDistribuidaGrupo * rutaItem.Count());

                        while (cantidadRestante > 0)
                        {
                            for (int i = 0; i < rutaItem.Count(); i++)
                            {
                                if (cantidadRestante == 0) break;
                                rutaItems[i].grupoCantidad += 1;
                                cantidadRestante -= 1;
                            }
                        }

                        for (int i = 0; i < rutaItems.Count(); i++)
                        {
                            rutaItems[i].grupoCantidad += cantidadDistribuidaGrupo;
                            rutaItems[i].rutaId = rutaItem.Key;

                            SetAssigningGrupoRuteo(preRuteoId, rutaItems[i]);
                        }

                    }
                }
            }
            catch (System.Exception ex)
            {
                LogEvent log = new LogEvent();
                log.LogWrite(ex.Message);
            }


        }

        private void SetAssigningGrupoRuteo(long preRuteoId, RuteoGrupoDTO ruteoGrupo)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_Update_RuteoAsignarGrupos]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ruteoId", preRuteoId);
                        command.Parameters.AddWithValue("@grupoId", ruteoGrupo.grupoId);
                        command.Parameters.AddWithValue("@rutaId", ruteoGrupo.rutaId);
                        command.Parameters.AddWithValue("@cantidadAsignada", ruteoGrupo.grupoCantidad);
                        command.CommandTimeout = 0;

                        command.ExecuteNonQuery();
                        //var adapter = new SqlDataAdapter(command);
                        //adapter.Fill(dataSet);
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


        private List<RuteoGrupoDTO> GetRutasByGrupoId(long preRuteoId, List<RuteoGrupoDTO> ruteosGrupos)
        {
            List<RuteoGrupoDTO> rutasGruposItems = new List<RuteoGrupoDTO>();

            foreach (var ruteoGrupoItem in ruteosGrupos)
            {
                var dataSet = new DataSet();
                using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
                {
                    connection.Open();
                    try
                    {
                        using (var command = new SqlCommand("[dbo].[SP_GET_RutasRuteoxGrupoId]", connection))
                        {
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@preRuteoId", preRuteoId);
                            command.Parameters.AddWithValue("@grupoId", ruteoGrupoItem.grupoId);

                            command.CommandTimeout = 0;


                            var adapter = new SqlDataAdapter(command);
                            adapter.Fill(dataSet);

                            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                            {
                                RuteoGrupoDTO ruteoGrupoItemAux = new RuteoGrupoDTO();
                                ruteoGrupoItemAux.grupoCantidad = (int)dataSet.Tables[0].Rows[i][2];
                                ruteoGrupoItemAux.grupoId = (long)dataSet.Tables[0].Rows[i][1];
                                ruteoGrupoItemAux.rutaId = (long)dataSet.Tables[0].Rows[i][0];
                                rutasGruposItems.Add(ruteoGrupoItemAux);
                            }                           

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
            return rutasGruposItems;
        }

        public void SP_Update_RuteoPedidosOrdenBahias(long preRuteoId, List<PedidoOrdenBahiaInfoDTO> pedidoOrdenBahiaInfo)
        {
            try
            {
                RuteosPedidos ruteoPedido = new RuteosPedidos();
                foreach (var pedidoRuteoItem in pedidoOrdenBahiaInfo)
                {
                    ruteoPedido = new RuteosPedidos();
                    ruteoPedido = (from p in dbcontext.RuteosPedidos
                                   where p.ruteoId == preRuteoId
                                       && p.pedidoId == pedidoRuteoItem.pedidoId
                                   select p).FirstOrDefault();

                    if (ruteoPedido == null) continue;
                    ruteoPedido.pedidoOrden = (short)pedidoRuteoItem.pedidoOrden;
                    ruteoPedido.bahiaId = pedidoRuteoItem.pedidoUbicacionBahiaId;

                    dbcontext.Entry(ruteoPedido).State = EntityState.Modified;


                    Ubicaciones ubicacion = new Ubicaciones();
                    ubicacion = (from p in dbcontext.Ubicaciones
                                   where p.ubicacionId == pedidoRuteoItem.pedidoUbicacionBahiaId
                                     && p.ubicacionDespacho == false
                                   select p).FirstOrDefault();

                    if (ubicacion == null) continue;

                    ubicacion.ubicacionDespacho = true;
                    dbcontext.Entry(ubicacion).State = EntityState.Modified;

                    dbcontext.SaveChanges();

                }
            }
            catch (System.Exception ex)
            {
                LogEvent log = new LogEvent();
                log.LogWrite(ex.Message);


            }

        }

    }

}
