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
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class ProductoNoConformeDAL : IProductoNoConformeDAL
    {
        public TecnoCEDI_bdContext dbcontext;
        /// <summary>
        /// Constructor, se genera una instancia del contexto de la base de datos
        /// </summary>
        public ProductoNoConformeDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }

        public DataSet setGuardarNovedadesProductoNoConforme(List<ProductoNoConformeGuardarNovedadesDTO> parametrosContenedoresNovedad)
        {
            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {
                    using (var command = new SqlCommand("[dbo].[sp_SET_ProductoNoConformeGuardarNovedades]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // 1. Crear el DataTable con la estructura exacta del TYPE en SQL
                        DataTable dtNovedades = new DataTable();
                        dtNovedades.Columns.Add("ContenedorId", typeof(long)); // long mapea a BIGINT
                        dtNovedades.Columns.Add("NovedadId", typeof(int));
                        dtNovedades.Columns.Add("UbicacionId", typeof(int));
                        dtNovedades.Columns.Add("UsuarioId", typeof(int));

                        // 2. Llenar el DataTable iterando sobre los elementos del DTO
                        if (parametrosContenedoresNovedad != null)
                        {
                            foreach (var item in parametrosContenedoresNovedad)
                            {
                                dtNovedades.Rows.Add(item.contenedorId, item.novedadId, item.ubicacionId, item.usuarioId);
                            }
                        }

                        // 3. Crear el parámetro estructurado y agregarlo al comando
                        SqlParameter paramNovedades = command.Parameters.AddWithValue("@dtNovedades", dtNovedades);
                        paramNovedades.SqlDbType = SqlDbType.Structured;
                        paramNovedades.TypeName = "dbo.NovedadProductoNoConformeType"; // Debe coincidir exactamente con el nombre en SQL

                        // 4. Ejecutar y llenar el DataSet
                        var adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataSet);
                    }
                }
                catch (Exception ex)
                {
                    LogEvent log = new LogEvent();
                    log.LogWrite(ex.Message);
                    return null;
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }

            return dataSet;
        }
    }
}