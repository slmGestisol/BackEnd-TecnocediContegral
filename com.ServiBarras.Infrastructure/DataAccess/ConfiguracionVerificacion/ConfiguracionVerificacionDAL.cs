
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.LogEvent;
using com.ServiBarras.Shared.ModelDTO;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class ConfiguracionVerificacionDAL : IConfiguracionVerificacionDAL
    {
        public TecnoCEDI_bdContext dbcontext;

        public ConfiguracionVerificacionDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }

      
        public async Task<ConfiguracionVerificacion> GetConfiguracionVerificacion(string tipo)
        {
            try
            {
                 ConfiguracionVerificacion configuracionVerificacionItem = new ConfiguracionVerificacion();
               

                  configuracionVerificacionItem = await dbcontext.ConfiguracionVerificacion.Where(x => x.configuracionVerificacionCodigo.ToUpper() == tipo.ToUpper()).FirstOrDefaultAsync();

                 

                  if (configuracionVerificacionItem == null) configuracionVerificacionItem = new ConfiguracionVerificacion();


                  return configuracionVerificacionItem;
              
            }
            catch (System.Exception ex)
            {
                LogEvent log = new LogEvent();
                log.LogWrite(ex.Message);
                return null;
            }
        }



    }
}
