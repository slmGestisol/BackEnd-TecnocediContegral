using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Contenedores
    {
        public Contenedores()
        {
            ARC_SaldosDetalle = new HashSet<ARC_SaldosDetalle>();
            InversecontenedorPadre = new HashSet<Contenedores>();
            PlantillasContenedores = new HashSet<PlantillasContenedores>();
            PreRuteosDetalle = new HashSet<PreRuteosDetalle>();
            ProductosContenedores = new HashSet<ProductosContenedores>();
            SaldosDetalle = new HashSet<SaldosDetalle>();
        }

        public long contenedorId { get; set; }
        public string contenedorCodigo { get; set; }
        public long? contenedorPadreId { get; set; }
        public long tipoContenedorId { get; set; }
        public int? contenedorEstibaConsecutivo { get; set; }
        public long? ultimaPresentacionId { get; set; }
        public string promocionDetalleCodigo { get; set; }

        public virtual Contenedores contenedorPadre { get; set; }
        public virtual TiposContenedores tipoContenedor { get; set; }
        public virtual ICollection<ARC_SaldosDetalle> ARC_SaldosDetalle { get; set; }
        public virtual ICollection<Contenedores> InversecontenedorPadre { get; set; }
        public virtual ICollection<PlantillasContenedores> PlantillasContenedores { get; set; }
        public virtual ICollection<PreRuteosDetalle> PreRuteosDetalle { get; set; }
        public virtual ICollection<ProductosContenedores> ProductosContenedores { get; set; }
        public virtual ICollection<SaldosDetalle> SaldosDetalle { get; set; }
    }
}
