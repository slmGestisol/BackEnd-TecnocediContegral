using System.Data;
using System.Threading.Tasks;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IMonitorOperarioBL
    {
        Task<DataSet> GetInformacionOperarioAsync(long usuarioId);
    }
}
