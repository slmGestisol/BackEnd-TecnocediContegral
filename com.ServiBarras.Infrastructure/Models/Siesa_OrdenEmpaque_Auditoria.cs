using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Siesa_OrdenEmpaque_Auditoria
    {
        public decimal Id { get; set; }
        public decimal? ordenEmpaqueId { get; set; }
        public decimal? UbicacionId { get; set; }
        public decimal? presentacionId { get; set; }
        public string ArchivoNombre { get; set; }
        public DateTime? Fecha { get; set; }
        public int? RowCount_auditoria { get; set; }
        public long? ordenEmpaqueIdAUX { get; set; }
        public string Error_Auditoria { get; set; }
        public long? N_ordenes { get; set; }
    }
}
