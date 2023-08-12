using System.Data;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IConfiguracionVerificacionBL
    {
        Task<ConfiguracionVerificacion> GetConfiguracionVerificacion(string tipo);
    }
}