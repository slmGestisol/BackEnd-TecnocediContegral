using System.Data;
using com.ServiBarras.Shared.ModelDTO;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IOrdenEmpaqueDAL
    {
        DataSet OrdenEmpaqueCambiarUbicacion(OrdenEmpaqueDTO empaqueDTO);
        DataSet OrdenEmpaqueCierreUbicacionEstiba(OrdenEmpaqueDTO empaqueDTO);
        DataSet OrdenEmpaqueEstacionTrabajoUsuario(OrdenEmpaqueDTO empaqueDTO);
        DataSet OrdenEmpaqueEliminarContenedor(OrdenEmpaqueDTO ordenAux);
        DataSet OrdenEmpaqueContenedorUbicacion(OrdenEmpaqueDTO ordenEmpaqueAux);
        DataSet SetSiesaPlanoInventario(OrdenEmpaqueDTO empaqueDTO);
        DataSet OrdenEmpaqueContenedorByContenedorCodigo(OrdenEmpaqueDTO contenedorItem);
        DataSet ValidarOdenEmpaqueSaldoUbicacion(OrdenEmpaqueDTO empaqueDTO);
        DataSet getOrdenesEmpaque();
        DataSet setGenerarOrdenEmpaque(generarOrdenEmpaqueDTO generarOrdenEmpaqueDTO);
        DataSet setActivarOrdenEmpaque(long ordenEmpaqueId);
        string setCerrarOrdenEmpaque(long ordenEmpaqueId);
        DataSet setOrdenEmpaqueFechaLote(cambioFechaLoteOrdenEmpaqueDTO parametrosOrden);
        DataSet getEstacionLoteByEstacionId(long estacionId);
        DataSet setEstacionLoteCambiarEstado(cambioEstadioEstacionLoteDTO cambioEstadioEstacionLoteDTO);
        DataSet setCerrarEstibaRecepcion(cerrarRecpcecionDTO parametrosCerrarRecepcion);
        DataSet getOrdenesExternas(string documento);
        DataSet setGenerarOrdenEmpaqueExterna(generarOrdenEmpaqueExternaDTO generarOrdenEmpaqueDTO);
        DataSet getValidarLoteExterno(string documento,long productoId,string LoteCodigo);
        DataSet getCiaExternos();
        DataSet setCerrarEstibaRecepcionCalidad(cerrarEstibaRecepcionCalidadDTO parametrosRecepcionCalidad);
        DataSet getTXOrdenEmpaqueById(long ordenEmpaqueId);
        DataSet setImprimirOrdenEmpaqueById(long txOrdenEmpaqueId);
    }
}