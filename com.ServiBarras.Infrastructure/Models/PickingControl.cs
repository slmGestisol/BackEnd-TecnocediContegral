using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class PickingControl
    {
        public long controlId { get; set; }
        public long? ruteoId { get; set; }
        public long? ruteoDetalleId { get; set; }
        public string contenedorTag { get; set; }
        public string ubicacionTag { get; set; }
        public long? novedadId { get; set; }
        public long? novedadAccionId { get; set; }
        public long? usuarioId { get; set; }
        public long? bahiaIdDestino { get; set; }
        public long? pedidoId { get; set; }
        public long? ruteoIdAux { get; set; }
        public long? ruteoDetalleIdAux { get; set; }
        public long? valorProductoLoteIdAux { get; set; }
        public long? ubicacionIdAux { get; set; }
        public bool? continuidadActivada { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
