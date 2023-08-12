using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface ICoronaExtrasBL
    {
        DataSet getMercadosEstandaresByProducto(long productoId);
    }
}