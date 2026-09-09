using System.Collections.Generic;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.ModelDTO;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    /// <summary>
    /// Parametrización de ubicaciones contra UbicacionesListas /
    /// UbicacionesListasDetalle.
    /// </summary>
    public interface IUbicacionListaBL
    {
        Task<IReadOnlyList<UbicacionListaSegmentoDTO>> ObtenerSegmentosAsync(UbicacionListaFiltroDTO filtro);

        Task<IReadOnlyList<UbicacionListaCatalogoDTO>> ObtenerCatalogoAsync();

        Task<IReadOnlyList<TiposUbicaciones>> ObtenerTiposUbicacionAsync();

        Task<IReadOnlyList<UbicacionListaConsultaDTO>> ConsultarUbicacionesAsync(UbicacionListaFiltroDTO filtro);

        Task<UbicacionListaRespuestaDTO> AsignarListasAsync(UbicacionListaAsignacionDTO asignacion);
    }
}
