using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class TiposContenedores
    {
        public TiposContenedores()
        {
            Contenedores = new HashSet<Contenedores>();
        }

        public long tipoContenedorId { get; set; }
        public decimal? tipoContenedorAncho { get; set; }
        public decimal? tipoContenedorAlto { get; set; }
        public decimal? tipoContenedorProfundidad { get; set; }
        public byte tipoContenedorMultiproducto { get; set; }
        public byte tipoContenedorMultilote { get; set; }
        public string tipoContenedorDescripcion { get; set; }
        public string tipoContenedorCodigo { get; set; }
        public decimal? tipoContenedorPeso { get; set; }
        public decimal? tipoContenedorVolumen { get; set; }

        public virtual ICollection<Contenedores> Contenedores { get; set; }
    }
}
