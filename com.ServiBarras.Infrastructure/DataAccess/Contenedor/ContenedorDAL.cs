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

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class ContenedorDAL : IContenedorDAL
    {

        public TecnoCEDI_bdContext dbcontext;


        public ContenedorDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }


        public async Task<List<Contenedores>> GetContenedoresAsync()
        {
            return await dbcontext.Contenedores.ToListAsync();
        }



        public async Task<Contenedores> GetContenedorAsync(long contenedorId)
        {
            var contenedor = await dbcontext.Contenedores.FindAsync(contenedorId);
            return contenedor;
        }



        public void AddContenedor(Contenedores contenedor)
        {
            dbcontext.Contenedores.Add(contenedor);
            dbcontext.SaveChangesAsync();

        }

        public DataSet GetContenedoresByContenedorCodigo(ContenedorUbicacionParcialDTO contenedor)
        {

            if (contenedor == null) return null;

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_GET_ContenedoresByContenedorCodigo]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ContenedorCodigo", contenedor.contenedorCodigo);
                        command.Parameters.AddWithValue("@UbicacionId", contenedor.ubicacionId);
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

        public DataSet GetContenedoresByContenedorCodigoBarcode(string contenedorCodigo)
        {
          
            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[SP_GET_ContenedoresByContenedorCodigoBarcode]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@contenedorCodigo", contenedorCodigo);
                        
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

        public DataSet GetValidarContenedorExterno(ContenedorUbicacionParcialDTO contenedorAux)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_ValidarContenedorExterno]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ubicacionId", contenedorAux.ubicacionId);
                        command.Parameters.AddWithValue("@contenedorCodigo", contenedorAux.contenedorCodigo);
                        command.Parameters.AddWithValue("@presentacionId", contenedorAux.presentacionId);
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

        public DataSet GetValidarContenedorByUbicacion(ContenedorUbicacionParcialDTO contenedor)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[SP_GET_ValidarContenedorCodigo]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ubicacionId", contenedor.ubicacionId);
                        command.Parameters.AddWithValue("@contenedorCodigo", contenedor.contenedorCodigo);
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

       

        public void DeleteContenedor(long contenedorId)
        {
            var contenedor = dbcontext.Contenedores.Find(contenedorId);
            if (contenedor == null)
            {

            }

            dbcontext.Contenedores.Remove(contenedor);
            dbcontext.SaveChanges();


        }

        public bool ContenedorExists(long contenedorId)
        {
            return dbcontext.Contenedores.Any(e => e.contenedorId == contenedorId);
        }
    }
}