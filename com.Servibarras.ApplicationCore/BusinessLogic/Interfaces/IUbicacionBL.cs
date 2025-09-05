using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IUbicacionBL
    {
        Task<Ubicaciones> GetUbicacionAsync(long ubicacionId);
        Task<List<Ubicaciones>> GetUbicacionesAsync();

        Task<List<Ubicaciones>> GetUbicacionesByTipoUbicacionAsync(JObject parametrosUbicacion);
        DataSet GetCodigoUbicacionByUsuarioId(long usuarioId,int isExportacion);
        string GetCodigoUbicacionPuertaByBahiaId(long bahiaId);

        string GetCodigoUbicacionByBahiaPadreId(JObject parametrosUbicacion);
        DataSet getruteoDetalleUbicacionCapturada(JObject parametrosUbicacion);
        DataSet GetCodigoReubicacionByUsuarioId(long usuarioId,int isExportacion);
        DataSet getPuertasUbicaciones(long instalacionId);
        DataSet GetContenedoresByUbicacionesCodigo(string ubicacionCodigo);
        DataSet GetUbicacionByUbicacionCodigo(string ubicacionCodigo, long instalacionId);
        DataSet GetDespachoParcialUbicaciones(long instalacionId);
        DataSet GetBahiasDisponiblesByBahiaPadre(JObject parametrosUbicacion);
        DataSet GetUbicacionByUbicacionCodigoBarcode(string ubicacionCodigo, string proceso, long instalacionId,long usuarioId);
    }
}