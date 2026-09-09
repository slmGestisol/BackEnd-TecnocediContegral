using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.ModelDTO;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IReabastecimientoBL
    {
        /// <summary>
        /// Obtiene el estado de reabastecimiento de todos los productos
        /// (resultado de sp_GET_ReabastecimientoData).
        /// </summary>
        Task<IReadOnlyList<ReabastecimientoItemDto>> ObtenerReabastecimientoAsync();

        /// <summary>
        /// Obtiene el saldo sugerido de reabastecimiento para un producto en una instalación
        /// (resultado de sp_GET_ReabastecimientoSaldoSugeridoByProductoId).
        /// </summary>
        DataSet ObtenerSaldoSugeridoByProductoId(int productoId, long instalacionId);

        /// <summary>
        /// Obtiene las ubicaciones por reabastecer para un producto en una instalación
        /// (resultado de sp_GET_ubicacionesPorReabastecerByProductoId).
        /// </summary>
        DataSet ObtenerUbicacionesPorReabastecerByProductoId(int productoId, long instalacionId);
    }
}
