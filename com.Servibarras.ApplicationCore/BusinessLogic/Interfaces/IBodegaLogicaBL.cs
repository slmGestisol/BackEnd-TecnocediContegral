using System.Collections.Generic;
using System.Data;
using com.ServiBarras.Infrastructure.Models;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IBodegaLogicaBL
    {
        DataSet getBodegasLogicasByProcesoNombre(string procesoNombre);
    }
}