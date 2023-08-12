using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.ModelDTO;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IContenedorDAL
    {
        void AddContenedor(Contenedores contenedor);
        bool ContenedorExists(long contenedorId);
        void DeleteContenedor(long contenedorId);
        Task<Contenedores> GetContenedorAsync(long contenedorId);
        Task<List<Contenedores>> GetContenedoresAsync();     
        DataSet GetContenedoresByContenedorCodigo(ContenedorUbicacionParcialDTO contenedor);       
        DataSet GetValidarContenedorByUbicacion(ContenedorUbicacionParcialDTO contenedor);
        DataSet GetContenedoresByContenedorCodigoBarcode(string contenedorCodigo);
        DataSet GetValidarContenedorExterno(ContenedorUbicacionParcialDTO contenedorAux);
    }
}