using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class TiposCoordenadas
    {
        public TiposCoordenadas()
        {
            Coordenadas = new HashSet<Coordenadas>();
        }

        public long tipoCoordenadaId { get; set; }
        public string tipoCoordenadaDescripcion { get; set; }

        public virtual ICollection<Coordenadas> Coordenadas { get; set; }
    }
}
