using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class RecetaRef99DetalleWizard
    {
        public long RecetaRef99Id { get; set; }
        public long RecetaRef99DetalleId { get; set; }
        public string REFERENCIA_LINEA { get; set; }
        public string REFERENCIA_99 { get; set; }
        public string BODEGA_REF_99 { get; set; }
        public string MOTIVO_REF_99 { get; set; }
        public string CO_DOC_99 { get; set; }
        public string PREFIJO_REF_99 { get; set; }
    }
}
