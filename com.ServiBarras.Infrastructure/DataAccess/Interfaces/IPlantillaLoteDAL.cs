using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IPlantillaLoteDAL
    {
        void AddPlantillaLote(PlantillasLotes plantillaLote);
        void DeletePlantillaLote(long plantillaLoteId);
        Task<PlantillasLotes> GetPlantillaLoteAsync(long plantillaLoteId);
        Task<List<PlantillasLotes>> GetPlantillasLotesAsync();
        bool PlantillaLoteIdExists(long plantillaLoteId);
        Task UpdatePlantillaLoteAsync(long plantillaLoteId, PlantillasLotes plantillaLote);
    }
}