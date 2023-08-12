using System.Data;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.ModelDTO;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IConfiguracionVerificacionDAL
    {
        Task<ConfiguracionVerificacion> GetConfiguracionVerificacion(string tipo);
    }

}