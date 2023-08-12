using System.Data;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IOrdenEmpaqueBL
    {
        DataSet OrdenEmpaqueCambiarUbicacion(JObject parametrosOrdenJson);
        DataSet OrdenEmpaqueCierreUbicacionEstiba(JObject parametrosOrdenJson);
        DataSet OrdenEmpaqueEstacionTrabajoUsuario(JObject parametrosOrdenJson);
        DataSet OrdenEmpaqueEliminarContenedor(JObject parametrosOrden);
        DataSet OrdenEmpaqueContenedorByContenedorCodigo(JObject parametrosContenedor);
        DataSet OrdenEmpaqueContenedorUbicacion(JObject parametrosOrdenEmpaque);
        DataSet SetSiesaPlanoInventario(JObject parametrosOrden);
        DataSet ValidarOdenEmpaqueSaldoUbicacion(JObject parametrosOrden);
        DataSet getOrdenesEmpaque();
        DataSet setGenerarOrdenEmpaque(JObject parametrosOrden);
        DataSet setActivarOrdenEmpaque(long ordenEmpaqueId);
        string setCerrarOrdenEmpaque(long ordenEmpaqueId);
        DataSet setOrdenEmpaqueFechaLote(JObject parametrosOrden);
        DataSet getEstacionLoteByEstacionId(long estacionId);
        DataSet setEstacionLoteCambiarEstado(JObject parametrosCambioEstado);
        DataSet setCerrarEstibaRecepcion(JObject parametrosCerrarRecepcion);
        DataSet getOrdenesExternas(string documento);
        DataSet setGenerarOrdenEmpaqueExterna(JObject parametrosOrden);
        DataSet getValidarLoteExterno(string documento,long productoId,string LoteCodigo);
        DataSet getCiaExternos();
        DataSet setCerrarEstibaRecepcionCalidad(JObject parametrosRecepcionCalidad);
        DataSet getTXOrdenEmpaqueById(long ordenEmpaqueId);
        DataSet setImprimirOrdenEmpaqueById(long txOrdenEmpaqueId);
    }
}