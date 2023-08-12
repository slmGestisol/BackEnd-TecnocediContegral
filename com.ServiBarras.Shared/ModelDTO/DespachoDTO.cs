using System;

namespace com.ServiBarras.Shared.ModelDTO
{
    public class DespachoDTO
    {
        public long despachoId { get; set; }
        public long despachoDetalleId { get; set; }

        public string ubicacionCodigo { get; set; }
        public long? novedadId { get; set; }
        public long? novedadAccionId { get; set; }

        public long usuarioId { get; set; }
        public bool? continuidadActivada { get; set; }


    }

    public class PedidosDespachoDTO
    {
        public long ubicacionIdPuerta { get; set; }


        public string pedidos { get; set; }



    }

    public class DespachoParcialDTO
    {
        public DespachoParcialDTO()
        {
            id = 0;
        }
        public long? id { get; set; } 
        public long usuarioId { get; set; }
        public long EstibaId { get; set; }
        public long? ContenedorId { get; set; }
        public long? PuertaId { get; set; }
        public long? PedidoId { get; set; }
        public bool? Incomincompleto { get; set; }
        public Guid? uniqueProcessId { get; set; }
        
    }
    public class DespachoPickingPackingDTO
    {
        public long ruteoId { get; set; }
        public long usuarioId { get; set; }
    }

    public class DespachoParcialPedidosDTO
    {
        public long UbicacionId { get; set; }
        public long PresentacionId { get; set; }

        public long? pedidoId { get; set; }
        public long? usuarioId { get; set; }
    }

    public class DespachoBahiaRuteoDTO
    {
        public long puertaUbicacionId { get; set; }
        
        public long usuarioId { get; set; }
    }

    public class DespachoLibreCrearDocumento
    {
        public long bahiaId { get; set; }
        public string documentoERP { get; set; }
        public long usuarioId { get; set; }
    }

    public class DespachoLibreProcesarDocumento
    {
        public long usuarioId { get; set; }
        public string documentoERP { get; set; }
        public string estibaCodigo { get; set; }
        public long cantidad { get; set; }
        public long productoId { get; set; }
        public long ubicacionIdDestino { get; set; }
        public string estibaCodigoDestino { get; set; }
        public string proceso { get; set; }
        public string loteId { get; set; }

    }

    public class DespachoLibreCerrarDocumento
    {
        public long usuarioId { get; set; }
        public string documentoERP { get; set; }
        public long ubicacionId { get; set; }
        public long cerrarDocumentosAsociados { get; set; }

    }
    public class DespachoLibreCambioPuerta
    {
        public long usuarioId { get; set; }
        public string documentoERP { get; set; }
        public long ubicacionId { get; set; }

    }

}
