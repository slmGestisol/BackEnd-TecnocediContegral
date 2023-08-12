using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class DetalleUnidadesEscalares
    {
        public long detalleUnidadEscalarId { get; set; }
        public string detalleUnidadEscalarCodigo { get; set; }
        public decimal? detalleUnidadEscalarCantidad { get; set; }
        public long unidadEscalarId { get; set; }
        public byte? detalleUnidadEscalarTipo { get; set; }
        public string detalleUnidadEscalarDescripcion { get; set; }

        public virtual UnidadesEscalares unidadEscalar { get; set; }
    }
}
