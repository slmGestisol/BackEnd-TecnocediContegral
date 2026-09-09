using System.Collections.Generic;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.ModelDTO;

namespace com.Servibarras.ApplicationCore.BusinessLogic.ConfigReabastecimiento
{
    public class ConfigReabastecimientoBL : IConfigReabastecimientoBL
    {
        private readonly IConfigReabastecimientoDAL _configReabastecimientoDAL;

        public ConfigReabastecimientoBL(IConfigReabastecimientoDAL configReabastecimientoDAL)
        {
            this._configReabastecimientoDAL = configReabastecimientoDAL;
        }

        public Task<IReadOnlyList<ConfigReabastecimientoItemDto>> ObtenerConfiguracionesAsync()
        {
            return this._configReabastecimientoDAL.ObtenerConfiguracionesAsync();
        }

        public Task<ConfigReabastecimientoDetalleDto> ObtenerDetalleAsync(long configReabastecimientoProductoId)
        {
            return this._configReabastecimientoDAL.ObtenerDetalleAsync(configReabastecimientoProductoId);
        }

        public Task<IReadOnlyList<ProductoSinConfigReabastecimientoDto>> ObtenerProductosSinConfigAsync()
        {
            return this._configReabastecimientoDAL.ObtenerProductosSinConfigAsync();
        }

        public Task<IReadOnlyList<UbicacionReabastecimientoDto>> ObtenerUbicacionesElegiblesAsync()
        {
            return this._configReabastecimientoDAL.ObtenerUbicacionesElegiblesAsync();
        }

        public Task<ConfigReabastecimientoResultDto> GuardarAsync(GuardarConfigReabastecimientoRequestDto request)
        {
            return this._configReabastecimientoDAL.GuardarAsync(request);
        }

        public Task<ConfigReabastecimientoResultDto> InactivarAsync(long configReabastecimientoProductoId, long usuarioId)
        {
            return this._configReabastecimientoDAL.InactivarAsync(configReabastecimientoProductoId, usuarioId);
        }
    }
}
