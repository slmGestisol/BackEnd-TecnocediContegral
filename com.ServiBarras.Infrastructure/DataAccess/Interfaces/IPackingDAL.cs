using System.Data;
using com.ServiBarras.Shared.ModelDTO;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IPackingDAL
    {
        string GetUbicacionByUserTag(long usuarioId);
        DataSet SPPackingRuteo(PackingDTO packingDTO);
        DataSet GetPackingDetallebyPackingId(PackingDetalleDTO packingJson);
        DataSet PackingDetalleUsuarioId(long? usuarioId);
    }
}