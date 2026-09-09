using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.ModelDTO;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IUbicacionDAL
    {
        Task<Ubicaciones> GetUbicacionAsync(long ubicacionId);
        Task<List<Ubicaciones>> GetUbicacionesAsync();
        Task<List<Ubicaciones>> GetUbicacionesByTipoUbicacionAsync(FilterBahiaDTO FilterBahiaDTO);
        DataSet GetCodigoUbicacionByUsuarioId(long usuarioId, string ubicacionCapturada);
        string GetCodigoUbicacionPuertaByBahiaId(long bahiaId);
        DataSet getruteoDetalleUbicacionCapturada(string ubicacionRequerida, string ubicacionCapturada);
        DataSet GetCodigoReubicacionByUsuarioId(long usuarioId, int isExportacion);
        DataSet getPuertasUbicaciones(long instalacionId);
        DataSet GetContenedoresByUbicacionesCodigo(string ubicacionCodigo, long instalacionId);
        DataSet GetUbicacionByUbicacionCodigo(string ubicacionCodigo,long instalacionId);
        DataSet GetDespachoParcialUbicaciones(long instalacionId, int incluirCompletas);
        string GetCodigoUbicacionByBahiaPadreId(UbicacionDTO ubicacionDTO);
        DataSet GetBahiasDisponiblesByBahiaPadre(UbicacionContingenciaDTO ubicacionContingenciaDTO);
        DataSet GetUbicacionByUbicacionCodigoBarcode(string ubicacionCodigo, string proceso, long instalacionId, long usuarioId);


    }
}