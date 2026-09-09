using System;
using System.Collections.Generic;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IDashboardBL
    {
        Dictionary<string, object> GetDashboardProduccion(DateTime fechaInicio, DateTime fechaFin);
    }
}
