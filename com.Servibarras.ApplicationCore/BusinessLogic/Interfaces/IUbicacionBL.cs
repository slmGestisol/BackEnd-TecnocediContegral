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
        DataSet GetCodigoUbicacionByUsuarioId(long usuarioId);
        string GetCodigoUbicacionPuertaByBahiaId(long bahiaId);

        string GetCodigoUbicacionByBahiaPadreId(JObject parametrosUbicacion);
        DataSet getruteoDetalleUbicacionCapturada(JObject parametrosUbicacion);
        DataSet GetCodigoReubicacionByUsuarioId(long usuarioId);
        DataSet getPuertasUbicaciones(long instalacionId);
        DataSet GetContenedoresByUbicacionesCodigo(string ubicacionCodigo);
        DataSet GetUbicacionByUbicacionCodigo(string ubicacionCodigo);
        DataSet GetDespachoParcialUbicaciones(long instalacionId);
        DataSet GetBahiasDisponiblesByBahiaPadre(JObject parametrosUbicacion);
        DataSet GetUbicacionByUbicacionCodigoBarcode(string ubicacionCodigo);
    }
}