using System.Data;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IProductoNoConformeBL
    {
        DataSet setGuardarNovedadesProductoNoConforme(JArray parametrosContenedoresNovedad);
    }
}