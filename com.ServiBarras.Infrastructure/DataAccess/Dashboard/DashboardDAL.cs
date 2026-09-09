using System;
using System.Data;
using System.Data.SqlClient;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.LogEvent;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess.Dashboard
{
    public class DashboardDAL : IDashboardDAL
    {
        public TecnoCEDI_bdContext dbcontext;

        public DashboardDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }

        public DataSet GetDashboardProduccion(DateTime fechaInicio, DateTime fechaFin)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var command = new SqlCommand("[dbo].[sp_GET_dashboardProduccion]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 0;
                        command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                        command.Parameters.AddWithValue("@fechaFin", fechaFin);
                        var adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataSet);
                    }

                    // Nombrar cada result set para facilitar el mapeo en el BL
                    if (dataSet.Tables.Count > 0) dataSet.Tables[0].TableName = "kpi_global";
                    if (dataSet.Tables.Count > 1) dataSet.Tables[1].TableName = "analisis_producto";
                    if (dataSet.Tables.Count > 2) dataSet.Tables[2].TableName = "detalle_producto_planos";
                    if (dataSet.Tables.Count > 3) dataSet.Tables[3].TableName = "resumen_mensual";
                    if (dataSet.Tables.Count > 4) dataSet.Tables[4].TableName = "resumen_mensual_turno";
                    if (dataSet.Tables.Count > 5) dataSet.Tables[5].TableName = "resumen_diario_turno";
                    if (dataSet.Tables.Count > 6) dataSet.Tables[6].TableName = "resumen_usuario";

                    return dataSet;
                }
                catch (Exception ex)
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
