using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.LogEvent;
using com.ServiBarras.Shared.ModelDTO;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class CrossDockingDAL : ICrossDockingDAL
    {
        public TecnoCEDI_bdContext dbcontext;
        public CrossDockingDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }

        public DataSet SetCrossDockingRuteoDetalle(CrossDockingDTO crossDockingDTO)
        {
            if (crossDockingDTO == null) return null;



            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_SET_CrossDockingRuteoDetalle]", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ruteoId", crossDockingDTO.ruteoId);
                        command.Parameters.AddWithValue("@contenedorTag", crossDockingDTO.contenedorTag);
                        command.Parameters.AddWithValue("@ubicacionTag", crossDockingDTO.ubicacionTag);
                        command.Parameters.AddWithValue("@novedadId", (crossDockingDTO.novedadId == null) ? 0 : crossDockingDTO.novedadId);
                        command.Parameters.AddWithValue("@novedadAccionId", (crossDockingDTO.novedadAccionId == null) ? 0 : crossDockingDTO.novedadAccionId);
                        command.Parameters.AddWithValue("@usuarioId", crossDockingDTO.usuarioId);
                        command.Parameters.AddWithValue("@bahiaIdDestino", (crossDockingDTO.bahiaIdDestino == null) ? 0 : crossDockingDTO.bahiaIdDestino);
                        command.Parameters.AddWithValue("@pedidoId", (crossDockingDTO.pedidoId == null) ? 0 : crossDockingDTO.pedidoId);
                        command.Parameters.AddWithValue("@continuidadActivada", crossDockingDTO.continuidadActivada);

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

        public DataSet getPickingCrossDocking()
        {
            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_GET_PickingCrossDocking]", connection))
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



        public DataSet GetFiltroBahiasProductosCrossDocking(FiltroBahiasProductosCrossDockingDTO crossDockingDTO)
        {
            if (crossDockingDTO == null) return null;

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_GET_FiltroBahiasProductosCrossDocking]", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ruteoId", crossDockingDTO.ruteoId);
                        command.Parameters.AddWithValue("@bahiaId", crossDockingDTO.bahiaId);
                        command.Parameters.AddWithValue("@productoId", crossDockingDTO.productoId);

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

        public DataSet GetCodigoUbicacionByUsuarioIdCrossDocking(UbicacionCrossDockingDTO crossDockingAux)
        {
            if (crossDockingAux == null) return null;
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_CodigoUbicacionByUsuarioIdCrossDocking]", connection))
                    {

                        if (crossDockingAux.ubicacionContinuidad==null)
                        {
                            crossDockingAux.ubicacionContinuidad = "";
                        }
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ruteoId", crossDockingAux.ruteoId);
                        command.Parameters.AddWithValue("@ubicacionContinuidad", crossDockingAux.ubicacionContinuidad);
                        command.Parameters.AddWithValue("@usuarioId", crossDockingAux.usuarioId);                        
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

        public DataSet GetSaldoDetalleRuteoCrossDocking(SaldoDetalleRuteoCrossDockingDTO saldoDetalleRuteoCrossDockingDTO)
        {

            if (saldoDetalleRuteoCrossDockingDTO == null) return null;
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_SaldoDetalleRuteoCrossDocking]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ubicacionId", saldoDetalleRuteoCrossDockingDTO.ubicacionId);
                        command.Parameters.AddWithValue("@ruteoId", saldoDetalleRuteoCrossDockingDTO.ruteoId);
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
