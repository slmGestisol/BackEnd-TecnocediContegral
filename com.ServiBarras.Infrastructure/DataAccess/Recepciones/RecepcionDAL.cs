using System;
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
    public class RecepcionDAL : IRecepcionDAL
    {
        public TecnoCEDI_bdContext dbcontext;
        /// <summary>
        /// Constructor, genera una instancia del contexto de la base de datos
        /// </summary>
        public RecepcionDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }
       
        public DataSet getRecepciones()
        {


            //dbcontext.Pedidos.
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[sp_GET_recepciones]", connection))
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
                    return null;

                }
                finally
                {
                    connection.Close();
                }

            }

            return dataSet;
        }

        public DataSet getRecepcionesDetalle(long recepcionId)
        {


            //dbcontext.Pedidos.
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[sp_GET_recepcionesDetalleByRecepcionId]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@recepcionId", recepcionId);

                        command.CommandTimeout = 0;

                        var adapter = new SqlDataAdapter(command);

                        adapter.Fill(dataSet);

                    }



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

            return dataSet;
        }

        public DataSet getRecepcionesContenedoresByContenedorCodigo(long recepcionId,string contenedorCodigo,bool contenedoresAsociados)
        {


            //dbcontext.Pedidos.
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[sp_GET_recepcionContenedoresByContenedorCodigo]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@recepcionId", recepcionId);
                        command.Parameters.AddWithValue("@contenedorCodigo", contenedorCodigo);
                        command.Parameters.AddWithValue("@contenedoresAsociados", contenedoresAsociados?1:0);
                        

                        command.CommandTimeout = 0;

                        var adapter = new SqlDataAdapter(command);

                        adapter.Fill(dataSet);

                    }



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

            return dataSet;
        }

        public DataSet getRecepcionValidacionUbicacion(string ubicacionCodigo,long instalacionId, long usuarioId)
        {
            //dbcontext.Pedidos.
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[sp_GET_RecepcionValidacionUbicacion]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ubicacionCodigo", ubicacionCodigo);
                        command.Parameters.AddWithValue("@instalacionId", instalacionId);
                        command.Parameters.AddWithValue("@usuarioId", usuarioId);
                        command.CommandTimeout = 0;

                        var adapter = new SqlDataAdapter(command);

                        adapter.Fill(dataSet);

                    }



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

            return dataSet;
        }

        public DataSet getRecepcionSerialesValidacionUbicacion(string ubicacionCodigo, long instalacionId, long usuarioId)
        {
            //dbcontext.Pedidos.
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[sp_GET_RecepcionSerialesValidacionUbicacion]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ubicacionCodigo", ubicacionCodigo);
                        command.Parameters.AddWithValue("@instalacionId", instalacionId);
                        command.Parameters.AddWithValue("@usuarioId", usuarioId);
                        command.CommandTimeout = 0;

                        var adapter = new SqlDataAdapter(command);

                        adapter.Fill(dataSet);

                    }



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

            return dataSet;
        }

        public DataSet setProcesarRecepcion(recepcionProcesarDTO recepcionProcesarDTO)
        {

            //dbcontext.Pedidos.
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[sp_SET_recepcionProcesar]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@recepcionId", recepcionProcesarDTO.recepcionId);
                        command.Parameters.AddWithValue("@usuarioId", recepcionProcesarDTO.usuarioId); 
                        command.Parameters.AddWithValue("@UbicacionIdDestino", recepcionProcesarDTO.UbicacionIdDestino); 
                        command.Parameters.AddWithValue("@documentoCodigo", (object)recepcionProcesarDTO.documentoCodigo ?? DBNull.Value); 

                        // Param: contenedores (tbl)
                        DataTable tbl = new DataTable();
                        tbl.Columns.Add("contenedorId", typeof(long));

                        foreach (var item in recepcionProcesarDTO.contenedoresRecepcion)
                        {
                            tbl.Rows.Add(item.contenedorId);
                        }

                        var tvpParam = command.Parameters.AddWithValue("@tblContenedoresRecepcion", tbl);
                        tvpParam.SqlDbType = SqlDbType.Structured;
                        tvpParam.TypeName = "ContenedoresRecepcionType";

                        command.CommandTimeout = 0;

                        var adapter = new SqlDataAdapter(command);

                        adapter.Fill(dataSet);

                    }



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

            return dataSet;
        }

        public DataSet setProcesarCierreUbicacion(ProcesarCerrarUbicacionDTO CerrarUbicacionDTO)
        {

            //dbcontext.Pedidos.
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[sp_SET_Recepcion_CerrarUbicacionEstiba]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@recepcionId", CerrarUbicacionDTO.recepcionId);
                        command.Parameters.AddWithValue("@usuarioId", CerrarUbicacionDTO.usuarioId);
                        command.Parameters.AddWithValue("@UbicacionId", CerrarUbicacionDTO.UbicacionId);
                        command.Parameters.AddWithValue("@impresoraId", CerrarUbicacionDTO.impresoraId);

                        command.CommandTimeout = 0;

                        var adapter = new SqlDataAdapter(command);

                        adapter.Fill(dataSet);

                    }



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

            return dataSet;
        }

        public DataSet setRecepcionEliminarContenenedor(EliminarContenedorRecepcionDTO contenedorEliminar)
        {

            //dbcontext.Pedidos.
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[sp_SET_RecepcionEliminarContenenedor]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@recepcionId", contenedorEliminar.recepcionId);
                        command.Parameters.AddWithValue("@usuarioId", contenedorEliminar.usuarioId);
                        command.Parameters.AddWithValue("@contenedorId", contenedorEliminar.contenedorId);
                        command.Parameters.AddWithValue("@ubicacionId", contenedorEliminar.ubicacionId);

                        command.CommandTimeout = 0;

                        var adapter = new SqlDataAdapter(command);

                        adapter.Fill(dataSet);

                    }

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

            return dataSet;
        }

        public DataSet setCerrarRecepcion(recepcionCerrarDTO recepcionCerrarDTO)
        {
            //dbcontext.Pedidos.
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {
                    using (var command = new SqlCommand("[dbo].[sp_SET_recepcionCerrar]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@recepcionId", recepcionCerrarDTO.recepcionId);
                        command.Parameters.AddWithValue("@usuarioId", recepcionCerrarDTO.usuarioId);

                        command.CommandTimeout = 0;

                        var adapter = new SqlDataAdapter(command);

                        adapter.Fill(dataSet);

                    }

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

            return dataSet;
        }
    }
}