using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class UnidadesEscalares
    {
        public UnidadesEscalares()
        {
            DetalleUnidadesEscalares = new HashSet<DetalleUnidadesEscalares>();
            PresentacioneslongitudEscalar = new HashSet<Presentaciones>();
            PresentacionespesoEscalar = new HashSet<Presentaciones>();
            PresentacionesvolumenEscalar = new HashSet<Presentaciones>();
            Productos = new HashSet<Productos>();
        }

        public long unidadEscalarId { get; set; }
        public string unidadEscalarDescripcion { get; set; }
        public string unidadEscalarCodigo { get; set; }
        public decimal? unidadEscalarCantidad { get; set; }
        public short unidadEscalarTipo { get; set; }

        public virtual ICollection<DetalleUnidadesEscalares> DetalleUnidadesEscalares { get; set; }
        public virtual ICollection<Presentaciones> PresentacioneslongitudEscalar { get; set; }
        public virtual ICollection<Presentaciones> PresentacionespesoEscalar { get; set; }
        public virtual ICollection<Presentaciones> PresentacionesvolumenEscalar { get; set; }
        public virtual ICollection<Productos> Productos { get; set; }
    }
}
