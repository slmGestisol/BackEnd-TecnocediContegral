using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.ModelDTO;

namespace com.Servibarras.ApplicationCore.BusinessLogic.UbicacionLista
{
    /// <summary>
    /// Parametrización de ubicaciones contra UbicacionesListas /
    /// UbicacionesListasDetalle. Valida la petición y normaliza el código
    /// antes de bajar al procedimiento; el rechazo por saldo lo decide el
    /// propio procedimiento, que es quien ve el estado de SaldosDetalle.
    /// </summary>
    public class UbicacionListaBL : IUbicacionListaBL
    {
        /// <summary>Largo del ubicacionCodigo que guarda la base.</summary>
        private const int LargoUbicacionCodigo = 16;

        private readonly IUbicacionListaDAL _ubicacionListaDAL;

        public UbicacionListaBL(IUbicacionListaDAL ubicacionListaDAL)
        {
            this._ubicacionListaDAL = ubicacionListaDAL;
        }

        public async Task<IReadOnlyList<UbicacionListaSegmentoDTO>> ObtenerSegmentosAsync(UbicacionListaFiltroDTO filtro)
        {
            return await this._ubicacionListaDAL.ObtenerSegmentosAsync(filtro ?? new UbicacionListaFiltroDTO());
        }

        public async Task<IReadOnlyList<UbicacionListaCatalogoDTO>> ObtenerCatalogoAsync()
        {
            return await this._ubicacionListaDAL.ObtenerCatalogoAsync();
        }

        public async Task<IReadOnlyList<TiposUbicaciones>> ObtenerTiposUbicacionAsync()
        {
            return await this._ubicacionListaDAL.ObtenerTiposUbicacionAsync();
        }

        public async Task<IReadOnlyList<UbicacionListaConsultaDTO>> ConsultarUbicacionesAsync(UbicacionListaFiltroDTO filtro)
        {
            var filtroAux = filtro ?? new UbicacionListaFiltroDTO();
            filtroAux.ubicacionCodigo = NormalizarUbicacionCodigo(filtroAux.ubicacionCodigo);

            return await this._ubicacionListaDAL.ConsultarUbicacionesAsync(filtroAux);
        }

        public async Task<UbicacionListaRespuestaDTO> AsignarListasAsync(UbicacionListaAsignacionDTO asignacion)
        {
            var validacion = Validar(asignacion);
            if (validacion != null)
            {
                return validacion;
            }

            return await this._ubicacionListaDAL.AsignarListasAsync(asignacion);
        }

        /// <summary>
        /// Devuelve el rechazo cuando la petición no da para llegar a la base,
        /// o null cuando puede seguir.
        /// </summary>
        private static UbicacionListaRespuestaDTO Validar(UbicacionListaAsignacionDTO asignacion)
        {
            if (asignacion == null)
            {
                return Rechazo("No se recibió información para aplicar");
            }

            if (asignacion.ubicaciones == null || !asignacion.ubicaciones.Any())
            {
                return Rechazo("Seleccione al menos una ubicación");
            }

            if (asignacion.ubicacionListaIds == null || !asignacion.ubicacionListaIds.Any())
            {
                return Rechazo("Seleccione al menos una lista");
            }

            if (string.IsNullOrWhiteSpace(asignacion.tipoUbicacionCodigo))
            {
                return Rechazo("Seleccione el tipo de ubicación");
            }

            if (asignacion.usuarioId <= 0)
            {
                return Rechazo("No se identificó el usuario que aplica el cambio");
            }

            return null;
        }

        private static UbicacionListaRespuestaDTO Rechazo(string mensaje)
        {
            return new UbicacionListaRespuestaDTO { exitoso = false, mensaje = mensaje };
        }

        /// <summary>
        /// La etiqueta y la pistola traen el indicativo de aplicación al
        /// frente; la columna guarda solo los 16 caracteres finales. Es la
        /// misma normalización que hacen los procesos de handheld.
        /// </summary>
        private static string NormalizarUbicacionCodigo(string ubicacionCodigo)
        {
            if (string.IsNullOrWhiteSpace(ubicacionCodigo))
            {
                return null;
            }

            var codigo = ubicacionCodigo.Trim();

            return codigo.Length > LargoUbicacionCodigo
                ? codigo.Substring(codigo.Length - LargoUbicacionCodigo)
                : codigo;
        }
    }
}
