using System.Data;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.ModelDTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic
{
    public class RecepcionBL : IRecepcionBL
    {
        private readonly IRecepcionDAL _recepcionDAL;
        public RecepcionBL(IRecepcionDAL recepcionDAL)
        {
            this._recepcionDAL = recepcionDAL;
        }

        public DataSet getRecepciones()
        {
            return this._recepcionDAL.getRecepciones();
        }
        public DataSet getRecepcionesDetalle(long recepcionId)
        {
            return this._recepcionDAL.getRecepcionesDetalle(recepcionId);
        }
        public DataSet getRecepcionesContenedoresByContenedorCodigo(long recepcionId,string contenedorCodigo, bool contenedoresAsociados)
        {
            return this._recepcionDAL.getRecepcionesContenedoresByContenedorCodigo(recepcionId,contenedorCodigo, contenedoresAsociados);
        }
        public DataSet getRecepcionValidacionUbicacion(string ubicacionCodigo, long instalacionId, long usuarioId)
        {
            return this._recepcionDAL.getRecepcionValidacionUbicacion(ubicacionCodigo, instalacionId, usuarioId);
        }
        public DataSet getRecepcionSerialesValidacionUbicacion(string ubicacionCodigo, long instalacionId, long usuarioId)
        {
            return this._recepcionDAL.getRecepcionSerialesValidacionUbicacion(ubicacionCodigo, instalacionId, usuarioId);
        }
        
        public DataSet setProcesarRecepcion(JObject recepcionProcesarDTO)
        {
            var recepcionAux = JsonConvert.DeserializeObject<recepcionProcesarDTO>(recepcionProcesarDTO.ToString());
            return this._recepcionDAL.setProcesarRecepcion(recepcionAux);
        }
        public DataSet setCerrarRecepcion(JObject recepcionCerrarDTO)
        {
            var recepcionAux = JsonConvert.DeserializeObject<recepcionCerrarDTO>(recepcionCerrarDTO.ToString());
            return this._recepcionDAL.setCerrarRecepcion(recepcionAux);
        }
        public DataSet setProcesarCierreUbicacion(JObject CerrarUbicacionDTO)
        {
            var recepcionAux = JsonConvert.DeserializeObject<ProcesarCerrarUbicacionDTO>(CerrarUbicacionDTO.ToString());
            return this._recepcionDAL.setProcesarCierreUbicacion(recepcionAux);
        }
        public DataSet setRecepcionEliminarContenenedor(JObject contenedorEliminar)
        {
            var contenedorEliminarAux = JsonConvert.DeserializeObject<EliminarContenedorRecepcionDTO>(contenedorEliminar.ToString());
            return this._recepcionDAL.setRecepcionEliminarContenenedor(contenedorEliminarAux);
        }

    }
}
