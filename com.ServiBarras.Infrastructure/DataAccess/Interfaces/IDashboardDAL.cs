using System;
using System.Data;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IDashboardDAL
    {
        DataSet GetDashboardProduccion(DateTime fechaInicio, DateTime fechaFin);
    }
}
