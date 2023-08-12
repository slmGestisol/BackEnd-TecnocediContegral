using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IRFIDBL
    {
        DataSet GetPortalRFIDContenedores(long idPortal,long despachoConsecutivo,string inicioCaptura);
    }
}