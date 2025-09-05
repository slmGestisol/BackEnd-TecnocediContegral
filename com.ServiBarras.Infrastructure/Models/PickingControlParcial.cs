using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class PickingControlParcial
    {
        public long ID { get; set; }
        public long? usuarioId { get; set; }
        public Guid? uniqueidentifier { get; set; }
        public long? ruteoId { get; set; }
        public long? ruteoDetalleId { get; set; }
        public string ubicacionTag { get; set; }
        public long? pedidoId { get; set; }
        public long? ruteoIdAux { get; set; }
        public long? ruteoDetalleIdAux { get; set; }
        public long? bahiaIdDestino { get; set; }
        public DateTime? fecha { get; set; }
    }
}
