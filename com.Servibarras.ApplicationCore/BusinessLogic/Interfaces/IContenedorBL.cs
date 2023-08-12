using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IContenedorBL
    {
        void AddContenedor(Contenedores contenedor);
        bool ContenedorExists(long contenedorId);
        void DeleteContenedor(long contenedorId);
        Task<Contenedores> GetContenedorAsync(long contenedorId);
        Task<List<Contenedores>> GetContenedoresAsync();
        DataSet GetContenedoresByContenedorCodigo(JObject parametrosContenedor);       
        DataSet GetValidarContenedorByUbicacion(JObject parametrosContenedor);
        DataSet GetContenedoresByContenedorCodigoBarcode(string contenedorCodigo);
        DataSet GetValidarContenedorExterno(JObject parametrosContenedor);
    }
}