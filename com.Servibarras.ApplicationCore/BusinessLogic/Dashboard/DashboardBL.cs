using System;
using System.Collections.Generic;
using System.Data;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Dashboard
{
    public class DashboardBL : IDashboardBL
    {
        private readonly IDashboardDAL _dashboardDAL;

        public DashboardBL(IDashboardDAL dashboardDAL)
        {
            this._dashboardDAL = dashboardDAL;
        }

        public Dictionary<string, object> GetDashboardProduccion(DateTime fechaInicio, DateTime fechaFin)
        {
            DataSet dataSet = this._dashboardDAL.GetDashboardProduccion(fechaInicio, fechaFin);
            if (dataSet == null) return null;

            // --- Tabla 1: kpi_global — fila única, se retorna como objeto ---
            var headerKpis = dataSet.Tables["kpi_global"]?.Rows.Count > 0
                ? DataRowToDict(dataSet.Tables["kpi_global"].Rows[0])
                : new Dictionary<string, object>();

            // --- Tabla 2 + Tabla 3: productos con drill-down de planos ---
            var tablaProductos = dataSet.Tables["analisis_producto"];
            var tablaPlanos    = dataSet.Tables["detalle_producto_planos"];

            var productos = new List<Dictionary<string, object>>();
            if (tablaProductos != null)
            {
                foreach (DataRow productoRow in tablaProductos.Rows)
                {
                    string codigo = productoRow["productoCodigo"]?.ToString();

                    // Filtrar los planos que pertenecen a este producto
                    var planos = new List<Dictionary<string, object>>();
                    if (tablaPlanos != null)
                    {
                        foreach (DataRow planoRow in tablaPlanos.Rows)
                        {
                            if (planoRow["productoCodigo"]?.ToString() == codigo)
                                planos.Add(DataRowToDict(planoRow));
                        }
                    }

                    productos.Add(new Dictionary<string, object>
                    {
                        ["id"]             = codigo,
                        ["descripcion"]    = productoRow.Table.Columns.Contains("productoDescripcion")
                                               ? productoRow["productoDescripcion"]?.ToString()
                                               : null,
                        ["datos_generales"] = DataRowToDict(productoRow),
                        ["planos_detalle"]  = planos
                    });
                }
            }

            // --- Tablas 4, 5, 6: histórico ---
            var historico = new Dictionary<string, object>
            {
                ["mensual"]         = DataTableToList(dataSet.Tables["resumen_mensual"]),
                ["mensual_turno"]   = DataTableToList(dataSet.Tables["resumen_mensual_turno"]),
                ["diario_turno"]    = DataTableToList(dataSet.Tables["resumen_diario_turno"])
            };

            // --- Tabla 7: resumen_usuario — agrupa por operario ---
            var tablaUsuarios = dataSet.Tables["resumen_usuario"];
            var usuarios = new List<Dictionary<string, object>>();
            if (tablaUsuarios != null)
            {
                // Detectar la columna de nombre del operario (Operario o primera columna)
                string colNombre = tablaUsuarios.Columns.Contains("Operario") ? "Operario"
                                 : tablaUsuarios.Columns.Contains("operario") ? "operario"
                                 : tablaUsuarios.Columns.Contains("usuario")  ? "usuario"
                                 : tablaUsuarios.Columns[0].ColumnName;

                foreach (DataRow row in tablaUsuarios.Rows)
                {
                    usuarios.Add(new Dictionary<string, object>
                    {
                        ["nombre"] = row[colNombre]?.ToString(),
                        ["kpis"]   = DataRowToDict(row)
                    });
                }
            }

            return new Dictionary<string, object>
            {
                ["header_kpis"] = headerKpis,
                ["productos"]   = productos,
                ["historico"]   = historico,
                ["usuarios"]    = usuarios
            };
        }

        // Convierte una DataRow en Dictionary preservando los tipos CLR (decimal, int, etc.)
        // Los campos TimeSpan (time en SQL) se formatean como "HH:mm:ss"
        private static Dictionary<string, object> DataRowToDict(DataRow row)
        {
            var dict = new Dictionary<string, object>();
            foreach (DataColumn col in row.Table.Columns)
            {
                object value = row[col];
                if (value == DBNull.Value)
                    dict[col.ColumnName] = null;
                else if (value is TimeSpan ts)
                    dict[col.ColumnName] = ts.ToString(@"hh\:mm\:ss");
                else
                    dict[col.ColumnName] = value; // decimal, int, string, DateTime → tipo nativo
            }
            return dict;
        }

        private static List<Dictionary<string, object>> DataTableToList(DataTable table)
        {
            var list = new List<Dictionary<string, object>>();
            if (table == null) return list;
            foreach (DataRow row in table.Rows)
                list.Add(DataRowToDict(row));
            return list;
        }
    }
}
