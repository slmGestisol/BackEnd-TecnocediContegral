using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Coordenadas
    {
        public Coordenadas()
        {
            InversecoordenadaPadre = new HashSet<Coordenadas>();
            RuteosDetalle = new HashSet<RuteosDetalle>();
            UbicacionesFisicas = new HashSet<UbicacionesFisicas>();
        }

        public long coordenadaId { get; set; }
        public int coordenadaSecuencia { get; set; }
        public int coordenadaNivel { get; set; }
        public long puntoOperacionId { get; set; }
        public long tipoCoordenada { get; set; }
        public long? coordenadaPadreId { get; set; }

        public virtual Coordenadas coordenadaPadre { get; set; }
        public virtual PuntosOperaciones puntoOperacion { get; set; }
        public virtual TiposCoordenadas tipoCoordenadaNavigation { get; set; }
        public virtual ICollection<Coordenadas> InversecoordenadaPadre { get; set; }
        public virtual ICollection<RuteosDetalle> RuteosDetalle { get; set; }
        public virtual ICollection<UbicacionesFisicas> UbicacionesFisicas { get; set; }
    }
}
