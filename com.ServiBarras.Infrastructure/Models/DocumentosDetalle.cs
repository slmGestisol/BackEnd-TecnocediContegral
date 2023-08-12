using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class DocumentosDetalle
    {
        public long documentoDetalleId { get; set; }
        public long documentoId { get; set; }
        public string documentoDetalleCodigo { get; set; }
        public string documentoDetalleNombre { get; set; }
        public long? ruteoMetodoId { get; set; }
        public int documentoDetalleMetodoOrden { get; set; }
        public string documentoDetalleMetodo { get; set; }
        public long? documentoDetalleTipoId { get; set; }
        public short? documentoDetalleDataOrigen { get; set; }

        public virtual Documentos documento { get; set; }
    }
}
