using System.Data;
using System.Threading.Tasks;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IMonitorOperarioDAL
    {
        Task<DataSet> GetInformacionReubicacionByUsuarioIdAsync(long usuarioId);
        Task<DataSet> GetInformacionPickingByUsuarioIdAsync(long usuarioId);
        Task<DataSet> GetInformacionDespachoByUsuarioIdAsync(long usuarioId);
    }
}
