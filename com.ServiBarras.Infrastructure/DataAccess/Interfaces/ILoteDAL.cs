using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using com.ServiBarras.Shared.ModelDTO;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface ILoteDAL
    {
        DataSet GetLoteByLoteCodigo(string loteCodigo, long productoId);
    }
}