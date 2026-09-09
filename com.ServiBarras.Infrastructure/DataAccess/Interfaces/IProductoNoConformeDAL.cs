using System.Collections.Generic;
using System.Data;
using com.ServiBarras.Shared.ModelDTO;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IProductoNoConformeDAL
    {
        DataSet setGuardarNovedadesProductoNoConforme(List<ProductoNoConformeGuardarNovedadesDTO> parametrosContenedoresNovedad);
    }
}