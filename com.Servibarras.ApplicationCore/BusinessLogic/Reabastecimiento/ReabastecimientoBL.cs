using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.ModelDTO;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Reabastecimiento
{
    public class ReabastecimientoBL : IReabastecimientoBL
    {
        private readonly IReabastecimientoDAL _reabastecimientoDAL;

        public ReabastecimientoBL(IReabastecimientoDAL reabastecimientoDAL)
        {
            this._reabastecimientoDAL = reabastecimientoDAL;
        }

        public Task<IReadOnlyList<ReabastecimientoItemDto>> ObtenerReabastecimientoAsync()
        {
            return this._reabastecimientoDAL.ObtenerReabastecimientoAsync();
        }

        public DataSet ObtenerSaldoSugeridoByProductoId(int productoId, long instalacionId)
        {
            return this._reabastecimientoDAL.ObtenerSaldoSugeridoByProductoId(productoId, instalacionId);
        }

        public DataSet ObtenerUbicacionesPorReabastecerByProductoId(int productoId, long instalacionId)
        {
            return this._reabastecimientoDAL.ObtenerUbicacionesPorReabastecerByProductoId(productoId, instalacionId);
        }
    }
}
