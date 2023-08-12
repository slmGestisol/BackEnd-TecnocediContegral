using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class ProcesoDAL : IProcesoDAL
    {
        public TecnoCEDI_bdContext dbcontext;
        /// <summary>
        /// Constructor, genera una instancia del contexto de la base de datos
        /// </summary>
        public ProcesoDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();

        }

        public List<Novedades> GetNovedadesByNameProceso(string nombreProceso)
        {
            Procesos procesoItem = new Procesos();
            procesoItem = dbcontext.Procesos.Where(x => x.ProcesoNombre == nombreProceso).FirstOrDefault();
            if (procesoItem == null)
            {
                return null;
            }

            List<Novedades> novedadesItems = new List<Novedades>();
            novedadesItems = dbcontext.Novedades.Where(x => x.procesoId == procesoItem.ProcesoId).ToList();

            if (nombreProceso.ToUpper() == "CALIDAD")
            {
                Novedades novedadItem = dbcontext.Novedades.Where(x => x.novedadCodigo == "000").FirstOrDefault();
                if (novedadItem != null)
                {
                    novedadesItems.Add(novedadItem);
                }
            }
            
            return novedadesItems;

        }



    }
}
