using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.LogEvent;
using com.ServiBarras.Shared.ModelDTO;
using com.ServiBarras.Shared.SqlData;
using com.ServiBarras.Shared.Utils;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class OrdenEmpaqueDAL : IOrdenEmpaqueDAL
    {
        public TecnoCEDI_bdContext dbcontext;
        /// <summary>
        /// Constructor, genera una instancia del contexto de la base de datos
        /// </summary>
        public OrdenEmpaqueDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }

        public DataSet OrdenEmpaqueCambiarUbicacion(OrdenEmpaqueDTO empaqueDTO)
        {

            if (empaqueDTO == null) return null;



            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_SET_OrdenEmpaqueCambiarUbicacion]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ubicacionId", empaqueDTO.ubicacionId);
                        command.Parameters.AddWithValue("@ubicacionCodigoCambio", (string.IsNullOrEmpty(empaqueDTO.ubicacionCodigo)?"": empaqueDTO.ubicacionCodigo));
                        command.Parameters.AddWithValue("@ordenEmpaqueId", empaqueDTO.ordenEmpaqueId);
                        command.Parameters.AddWithValue("@estacionId", empaqueDTO.estacionId);
                        command.Parameters.AddWithValue("@usuarioId", empaqueDTO.usuarioId);
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

        public DataSet ValidarOdenEmpaqueSaldoUbicacion(OrdenEmpaqueDTO empaqueDTO)
        {
            if (empaqueDTO == null) return null;



            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_GET_ValidarOdenEmpaqueSaldoUbicacion]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ordenEmpaqueId", empaqueDTO.ordenEmpaqueId);
                        command.Parameters.AddWithValue("@ubicacionId", empaqueDTO.ubicacionId);
                        command.Parameters.AddWithValue("@estacionId", empaqueDTO.estacionId);
                        command.Parameters.AddWithValue("@usuarioId", empaqueDTO.usuarioId);
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


        public DataSet OrdenEmpaqueEliminarContenedor(OrdenEmpaqueDTO ordenAux)
        {
            if (ordenAux == null) return null;



            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_SET_OrdenEmpaqueEliminarContenedor]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@contenedorId", ordenAux.contenedorId);
                        command.Parameters.AddWithValue("@ordenEmpaqueId", ordenAux.ordenEmpaqueId);
                        command.Parameters.AddWithValue("@ubicacionId", ordenAux.ubicacionId);
                        command.Parameters.AddWithValue("@estacionId", ordenAux.ubicacionId);
                        command.Parameters.AddWithValue("@usuarioId", ordenAux.usuarioId);

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

        public DataSet OrdenEmpaqueContenedorUbicacion(OrdenEmpaqueDTO ordenEmpaqueAux)
        {
            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_SET_OrdenEmpaqueContenedorUbicacion]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@contenedorCodigo", ordenEmpaqueAux.contenedorCodigo);
                        command.Parameters.AddWithValue("@ordenEmpaqueId", ordenEmpaqueAux.ordenEmpaqueId);
                        command.Parameters.AddWithValue("@ubicacionId", ordenEmpaqueAux.ubicacionId);
                        command.Parameters.AddWithValue("@estacionId", ordenEmpaqueAux.estacionId);
                        
                        command.Parameters.AddWithValue("@proceso", ordenEmpaqueAux.proceso);
                        command.Parameters.AddWithValue("@usuarioId", ordenEmpaqueAux.usuarioId);
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


        public DataSet OrdenEmpaqueCierreUbicacionEstiba(OrdenEmpaqueDTO empaqueDTO)
        {
           
            if (empaqueDTO == null) return null;



            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_SET_OrdenEmpaqueCierreUbicacionEstiba]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ubicacionId", empaqueDTO.ubicacionId);
                        command.Parameters.AddWithValue("@ordenEmpaqueId", empaqueDTO.ordenEmpaqueId);
                        command.Parameters.AddWithValue("@estacionId", empaqueDTO.estacionId);
                        command.Parameters.AddWithValue("@estadoEstibaUbicacion", empaqueDTO.estadoEstibaUbicacion);
                        command.Parameters.AddWithValue("@usuarioId", empaqueDTO.usuarioId);

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

        public DataSet OrdenEmpaqueEstacionTrabajoUsuario(OrdenEmpaqueDTO empaqueDTO)
        {

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_GET_OrdenEmpaqueEstacionTrabajoUsuario]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;                     
                        command.Parameters.AddWithValue("@usuarioId", empaqueDTO.usuarioId);
                        command.Parameters.AddWithValue("@ubicacionCodigo", empaqueDTO.ubicacionCodigo);
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

        public DataSet OrdenEmpaqueContenedorByContenedorCodigo(OrdenEmpaqueDTO contenedorItem)
        {
            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_GET_OrdenEmpaqueContenedorByContenedorCodigo]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@contenedorCodigo", contenedorItem.contenedorCodigo);
                        command.Parameters.AddWithValue("@ordenEmpaqueId", contenedorItem.ordenEmpaqueId);
                        command.Parameters.AddWithValue("@proceso", contenedorItem.proceso);
                        command.Parameters.AddWithValue("@usuarioId", contenedorItem.usuarioId);
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


        public DataSet SetSiesaPlanoInventario(OrdenEmpaqueDTO empaqueDTO)
        {
            if (empaqueDTO == null) return null;

            string writeLog = "";

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_SET_Siesa_Plano_Inventario]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ubicacionId", empaqueDTO.ubicacionId);
                        command.Parameters.AddWithValue("@ordenEmpaqueId", empaqueDTO.ordenEmpaqueId);
                        //command.Parameters.AddWithValue("@estacionId", empaqueDTO.estacionId);
                        //command.Parameters.AddWithValue("@presentacionId", empaqueDTO.presentacionId);
                        //command.Parameters.AddWithValue("@usuarioId", empaqueDTO.usuarioId);
                        command.CommandTimeout = 0;
                        var adapter = new SqlDataAdapter(command);

                        adapter.Fill(dataSet);

                    }
                    
                    if(dataSet != null)
                    {
                        if (dataSet.Tables.Count>0)
                        {
                            if (dataSet.Tables.Count > 1)
                            {

                                if (dataSet.Tables[1].Columns.Count > 4)
                                {
                                    writeLog = WriteDataToFile.DataTableData(dataSet.Tables[1]);
                                }
                               
                               

                                if (!string.IsNullOrEmpty(writeLog))
                                {
                                    writeLog += ", UbicacionId: " + empaqueDTO.ubicacionId +
                                        ", ordenEmpaqueId: " + empaqueDTO.ordenEmpaqueId +
                                        ", usuarioId: " + empaqueDTO.usuarioId;

                                    LogEvent logWriteDataToFile = new LogEvent();
                                    logWriteDataToFile.LogWrite(writeLog);

                                }
                                 dataSet.Tables.RemoveAt(1);

                               

                            }
                            
                        }   
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


        public DataSet getOrdenesEmpaque()
        {
            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_GET_OrdenesEmpaque]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                       
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


        public DataSet setGenerarOrdenEmpaque(generarOrdenEmpaqueDTO generarOrdenEmpaqueDTO)
        {
            if (generarOrdenEmpaqueDTO == null) return null;

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_SET_generarOrdenEmpaque]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@productoId", generarOrdenEmpaqueDTO.productoId);
                        command.Parameters.AddWithValue("@fechaFinalizacion", generarOrdenEmpaqueDTO.fechaFinalizacion);
                        command.Parameters.AddWithValue("@NUnidades", generarOrdenEmpaqueDTO.NUnidades);
                        command.Parameters.AddWithValue("@tipoEvalacion", generarOrdenEmpaqueDTO.tipoEvalacion);
                        command.Parameters.AddWithValue("@estacionId", generarOrdenEmpaqueDTO.estacionId);
                        command.Parameters.AddWithValue("@usuarioId", generarOrdenEmpaqueDTO.usuarioId);
                        command.Parameters.AddWithValue("@loteCodigo", generarOrdenEmpaqueDTO.loteCodigo);
                        command.Parameters.AddWithValue("@tipoOperacion", generarOrdenEmpaqueDTO.tipo); 
                        command.Parameters.AddWithValue("@docExterno", generarOrdenEmpaqueDTO.docExterno);
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

        public DataSet setActivarOrdenEmpaque(long ordenEmpaqueId)
        {
            if (ordenEmpaqueId == 0) return null;

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {
                    /*  string result = string.Empty;
                      var OrdenEmpaque = dbcontext.OrdenesEmpaque.Where(x => x.ordenEmpaqueId == ordenEmpaqueId).FirstOrDefault();


                      if (OrdenEmpaque == null)
                      {
                          result = "No se encontro la orden de empaque";
                          return result;
                      }

                      OrdenEmpaque.ordenEmpaqueEstado = 169;
                      dbcontext.SaveChanges();

                      result = "Se la orden se activo correctamente";

                      return result;*/


                    using (var command = new SqlCommand("[dbo].[SP_SET_ActivarOrdenEmpaque]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ordenEmpaqueId", ordenEmpaqueId);
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


        public string setCerrarOrdenEmpaque(long ordenEmpaqueId)
        {
            if (ordenEmpaqueId == 0) return null;

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {
                    string result = string.Empty;
                    var OrdenEmpaque = dbcontext.OrdenesEmpaque.Where(x => x.ordenEmpaqueId == ordenEmpaqueId).FirstOrDefault();


                    if (OrdenEmpaque == null)
                    {
                        result = "No se encontro la orden de empaque";
                        return result;
                    }

                    OrdenEmpaque.ordenEmpaqueEstado = 171;
                    dbcontext.SaveChanges();


                    using (var command = new SqlCommand("[dbo].[SP_SET_CerrarOrdenEmpaque]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ordenEmpaqueId", ordenEmpaqueId);
                        command.CommandTimeout = 0;

                        var adapter = new SqlDataAdapter(command);

                        adapter.Fill(dataSet);

                    }

                    result = "Se la orden se cerro correctamente";

                    return result;
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

        public DataSet setOrdenEmpaqueFechaLote(cambioFechaLoteOrdenEmpaqueDTO cambioFechaLoteOrdenEmpaqueDTO)
        {
            if (cambioFechaLoteOrdenEmpaqueDTO == null) return null;

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_SET_OrdenEmpaqueCambioLote]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ordenEmpaqueId", cambioFechaLoteOrdenEmpaqueDTO.ordenEmpaqueId);
                        command.Parameters.AddWithValue("@fecha", cambioFechaLoteOrdenEmpaqueDTO.fecha);                
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

        public DataSet getEstacionLoteByEstacionId(long estacionId)
        {
            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_GET_estacionLoteByEstacionId]", connection))
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

        public DataSet setEstacionLoteCambiarEstado(cambioEstadioEstacionLoteDTO cambioEstadioEstacionLoteDTO)
        {
            if (cambioEstadioEstacionLoteDTO == null) return null;

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_SET_estacionLoteCambioEstado]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@estacionId", cambioEstadioEstacionLoteDTO.estacionId);
                        command.Parameters.AddWithValue("@valor", cambioEstadioEstacionLoteDTO.valor);
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

        public DataSet setCerrarEstibaRecepcion(cerrarRecpcecionDTO parametrosCerrarRecepcion)
        {

            if (parametrosCerrarRecepcion == null) return null;

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_SET_CerrarEstibaRecepcion]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ubicacionId", parametrosCerrarRecepcion.ubicacionId);
                        command.Parameters.AddWithValue("@cantidad", parametrosCerrarRecepcion.cantidad);
                        command.Parameters.AddWithValue("@ordenEmpaqueId", parametrosCerrarRecepcion.ordenEmpaqueId);
                        command.Parameters.AddWithValue("@estibaCodigo", parametrosCerrarRecepcion.estibaCodigo);
                        command.Parameters.AddWithValue("@LoteCodigo", parametrosCerrarRecepcion.loteCodigo);
                        command.Parameters.AddWithValue("@FechaVencimientoLote", parametrosCerrarRecepcion.LoteFechaVencimiento);
                        command.Parameters.AddWithValue("@usuarioId", parametrosCerrarRecepcion.usuarioId);


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

        public DataSet getOrdenesExternas(string documento)
        {
            if (documento == null) return null;

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[sp_GET_OrdenesExternas]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Documento", documento);
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

        public DataSet setGenerarOrdenEmpaqueExterna(generarOrdenEmpaqueExternaDTO generarOrdenEmpaqueDTO)
        {
            if (generarOrdenEmpaqueDTO == null) return null;

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[sp_SET_generarOrdenEmpaqueExternas]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@documentoERP", generarOrdenEmpaqueDTO.documentoERP);
                        command.Parameters.AddWithValue("@tipoDoc", generarOrdenEmpaqueDTO.tipoDoc);
                        command.Parameters.AddWithValue("@estacionId", generarOrdenEmpaqueDTO.estacionId);
                        command.Parameters.AddWithValue("@usuarioId", generarOrdenEmpaqueDTO.usuarioId);
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

        public DataSet getValidarLoteExterno(string documento,long productoId,string LoteCodigo)
        {

            if (LoteCodigo == null || documento == null) return null;

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_GET_ValidarLoteExterno]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@loteCodigo", LoteCodigo);
                        command.Parameters.AddWithValue("@productoId", productoId);
                        command.Parameters.AddWithValue("@documentoERP", documento);



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
        public DataSet getCiaExternos()
        {

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_GET_CIAExternos]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;


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

        public DataSet setCerrarEstibaRecepcionCalidad(cerrarEstibaRecepcionCalidadDTO parametrosRecepcionCalidad)
        {
            if (parametrosRecepcionCalidad == null) return null;

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[sp_SET_CerrarEstibaRecepcionCalidad]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ordenEmpaqueId", parametrosRecepcionCalidad.ordenEmpaqueId);
                        command.Parameters.AddWithValue("@usuarioId", parametrosRecepcionCalidad.usuarioId);
                        command.Parameters.AddWithValue("@cantidad", parametrosRecepcionCalidad.cantidad);
                        command.Parameters.AddWithValue("@loteCodigo", parametrosRecepcionCalidad.loteCodigo);
                        command.Parameters.AddWithValue("@productoCodigoValicacion", parametrosRecepcionCalidad.productoCodigoValidacion);
                        command.Parameters.AddWithValue("@estadoCalidad", parametrosRecepcionCalidad.estadoCalidad);

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

        public DataSet getTXOrdenEmpaqueById(long ordenEmpaqueId)
        {
            if (ordenEmpaqueId == 0) return null;

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[sp_GET_TXOrdenEmpaqueById]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ordenEmpaqueId", ordenEmpaqueId);

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
        public DataSet setImprimirOrdenEmpaqueById(long txOrdenEmpaqueId)
        {
            if (txOrdenEmpaqueId == 0) return null;

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[sp_SET_ImprimirTXOrdenEmpaqueById]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@txOrdenEmpaqueId", txOrdenEmpaqueId);

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