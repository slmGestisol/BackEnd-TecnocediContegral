using System.Data;
using com.ServiBarras.Shared.ModelDTO;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
     public interface IClientesDAL
    {
        DataSet SetIntegrarClientes();
    }
}
