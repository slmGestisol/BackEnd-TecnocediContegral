using System.Data;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;

namespace com.Servibarras.ApplicationCore.BusinessLogic.MonitorOperario
{
    public class MonitorOperarioBL : IMonitorOperarioBL
    {
        private readonly IMonitorOperarioDAL _monitorOperarioDAL;

        public MonitorOperarioBL(IMonitorOperarioDAL monitorOperarioDAL)
        {
            this._monitorOperarioDAL = monitorOperarioDAL;
        }

        public async Task<DataSet> GetInformacionOperarioAsync(long usuarioId)
        {
            // Ejecutar ambos SPs en paralelo — tiempo total = el más lento, no la suma
            DataSet[] resultados = await Task.WhenAll(
                _monitorOperarioDAL.GetInformacionReubicacionByUsuarioIdAsync(usuarioId),
                _monitorOperarioDAL.GetInformacionPickingByUsuarioIdAsync(usuarioId),
                _monitorOperarioDAL.GetInformacionDespachoByUsuarioIdAsync(usuarioId)
            );

            DataSet reubicaciones = resultados[0];
            DataSet picking       = resultados[1];
            DataSet despacho       = resultados[2];

            // Si cualquiera falla retornar null — el controller devuelve 500
            if (reubicaciones == null || picking == null || despacho == null)
                return null;

            // Combinar en un único DataSet con tablas nombradas.
            // Newtonsoft serializa DataSet como: { "reubicaciones": [...], "picking": [...] }
            var resultado = new DataSet();

            DataTable tablaReubicaciones = reubicaciones.Tables[0].Copy();
            tablaReubicaciones.TableName = "reubicaciones";
            resultado.Tables.Add(tablaReubicaciones);

            DataTable tablaPicking = picking.Tables[0].Copy();
            tablaPicking.TableName = "picking";
            resultado.Tables.Add(tablaPicking);


            DataTable tablaDespacho = despacho.Tables[0].Copy();
            tablaDespacho.TableName = "despacho";
            resultado.Tables.Add(tablaDespacho);

            return resultado;
        }
    }
}
