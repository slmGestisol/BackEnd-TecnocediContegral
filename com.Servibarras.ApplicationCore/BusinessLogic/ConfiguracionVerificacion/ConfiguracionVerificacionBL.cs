using System.Data;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.ModelDTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class ConfiguracionVerificacionBL : IConfiguracionVerificacionBL
    {
        private readonly IConfiguracionVerificacionDAL _configuracionVerificacionDAL;
        public ConfiguracionVerificacionBL(IConfiguracionVerificacionDAL configuracionVerificacionDAL)
        {
            this._configuracionVerificacionDAL = configuracionVerificacionDAL;
        }

        public async Task<ConfiguracionVerificacion> GetConfiguracionVerificacion(string tipo)
        {
            return  await this._configuracionVerificacionDAL.GetConfiguracionVerificacion(tipo);
        }

    }
}
