using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.ModelDTO;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IReabastecimientoDAL
    {
        /// <summary>
        /// Ejecuta el stored procedure sp_GET_ReabastecimientoData y devuelve el estado
        /// de reabastecimiento de todos los productos.
        /// </summary>
        Task<IReadOnlyList<ReabastecimientoItemDto>> ObtenerReabastecimientoAsync();

        /// <summary>
        /// Ejecuta el stored procedure sp_GET_ReabastecimientoSaldoSugeridoByProductoId
        /// y devuelve el saldo sugerido de reabastecimiento para un producto en una instalación.
        /// </summary>
        DataSet ObtenerSaldoSugeridoByProductoId(int productoId, long instalacionId);

        /// <summary>
        /// Ejecuta el stored procedure sp_GET_ubicacionesPorReabastecerByProductoId
        /// y devuelve las ubicaciones por reabastecer para un producto en una instalación.
        /// </summary>
        DataSet ObtenerUbicacionesPorReabastecerByProductoId(int productoId, long instalacionId);
    }
}
